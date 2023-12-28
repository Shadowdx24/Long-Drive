using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float rotationAngle = 1.0f;
    private bool goingLeft;
    private bool goingRight;
    private float currHealth;
    [SerializeField]private float maxHealth = 10;
    [SerializeField] private Slider healthSlider;
    private int score = 0;
    private int money = 0;
    private float gameTime = 0f;
    [SerializeField] GameObject GameOverScene;
    [SerializeField] GameObject GamePauseScene;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        setHealth(currHealth);
    }

    // Update is called once per frame
    void Update()
    {
        MoveOnKeys();

        if(goingLeft)
        {
            LeftSide();
        }
       else if (goingRight)
        {
            RightSide();
        }
        else
        {
            resetRotation();
        }
        gameTime = Time.time;
        score = (int)gameTime;
        Debug.Log(score);
        money = (int)(score / 5);
      
    }
    private void LeftSide()
    {
        transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,rotationAngle),rotationSpeed*Time.deltaTime);
    }
    private void RightSide()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0,-rotationAngle), rotationSpeed * Time.deltaTime);
    }
    private void MoveOnKeys()
    {
        if (Input.GetKey(KeyCode.A))
        {
            goingLeft = true;
        }
       else if (Input.GetKey(KeyCode.D))
        {
           goingRight = true;
        }
        else
        {
            goingLeft=false;
            goingRight=false;
        }
    }
    private void resetRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            currHealth--;
            setHealth(currHealth);
            
            Destroy(collision.gameObject);
            if(currHealth == 0)
            {
                Debug.Log("Game Over");
                GameOver();
            }
        }
        else if (collision.gameObject.CompareTag("fuel"))
        {
            if(currHealth < maxHealth) 
            {
                currHealth++;
                setHealth(currHealth);
            }
            Destroy(collision.gameObject);
        }
    }
    private void setHealth(float val)
    {
        healthSlider.value = val;
    }
    private void GameOver()
    {
        GameOverScene.SetActive(true);
        Time.timeScale = 0f;
        scoreText.text = "Score :" + score;
        moneyText.text = "Money :" + money;
    }
    public void GamePause()
    {
        GamePauseScene.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        GamePauseScene.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        GameOverScene.SetActive(false);
        score = 0;
        money = 0;
        
    }
    public void GameHome()
    {
        SceneManager.LoadScene(0);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
