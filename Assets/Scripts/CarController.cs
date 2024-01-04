using TMPro;
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
    [SerializeField] private SpriteRenderer carSelection;
    [SerializeField] private Sprite[] carImages;
    private int currCar;
    private int currControls;
    [SerializeField] private Button BtnLeft;
    [SerializeField] private Button BtnRight;
    private float CurrCarSpeed=0.5f;
    [SerializeField] private Road CarRoad;
    
    void Start()
    {
        currHealth = maxHealth;
        setHealth(currHealth);
        currCar = PlayerPrefs.GetInt("MainCar");
        currControls = PlayerPrefs.GetInt("CurrControls");
        if(currControls == 2)
        {
            BtnLeft.gameObject.SetActive(true);
            BtnRight.gameObject.SetActive(true);
        }
        else
        {
            BtnLeft.gameObject.SetActive(false);
            BtnRight.gameObject.SetActive(false);
        }
        carSelection.sprite = carImages[currCar];
        AudioManager.instance.Play("Car");
    }

    void Update()
    {
        DetectInput();

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
        PlayerPrefs.SetInt("Money", money);     
    }

    private void DetectInput()
    {
        switch (currControls)
        {
            case 1:
                {
                    MoveOnKeys();
                    break;
                }
            case 2:
                {
                    break;       
                }
            case 3:
                {
                    MoveOnSensor();
                    break;
                }
            case 4:
                {
                    MoveOnTouch();
                    break;
                }
        }
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
    private void MoveOnSensor()
    {
        if (Input.acceleration.x < -0.1f)
        {
            goingLeft = true;
        }
        else if (Input.acceleration.x > 0.1f)
        {
            goingRight = true;
        }
        else
        {
            goingLeft = false;
            goingRight = false;
        }
    }
    private void MoveOnTouch()
    {
        if(Input.touchCount > 0)
        {
            Vector2 pos=Input.GetTouch(0).position;
            float middle = Screen.width / 2;
            if(pos.x < middle)
            {
                goingLeft=true;
            }
            else if(pos.x > middle)
            {
                goingRight=true;
            }
        }
        else 
        { 
            goingLeft = false;
            goingRight = false;
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
            AudioManager.instance.Play("Crash");

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
                AudioManager.instance.Play("Fuel");
            }
            Destroy(collision.gameObject);
            AudioManager.instance.Play("Fuel");
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
        AudioManager.instance.Play("Game Over");
        AudioManager.instance.Stop("Car");
        AudioManager.instance.Stop("CarBg");
    }

    public void GamePause()
    {
        GamePauseScene.SetActive(true);
        Time.timeScale = 0f;
        AudioManager.instance.Stop("Car");
        AudioManager.instance.Stop("CarBg");
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        GamePauseScene.SetActive(false);
        AudioManager.instance.Play("Car");
        AudioManager.instance.Play("CarBg");
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        GameOverScene.SetActive(false);
        score = 0;
        money = 0;
        AudioManager.instance.Stop("Game Over");
        AudioManager.instance.Play("CarBg");
    }
    
    public void GameHome()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.Play("Home");
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
    
    public void RightBtnDown()
    {
        goingRight=true;
    }
    public void RightBtnUp()
    {
        goingRight = false;
    }
    public void LeftBtnDown()
    {
        goingLeft = true;
    }
    public void LeftBtnUp()
    {
        goingLeft = false;
    }
    public void Accelerate()
    {
        CurrCarSpeed += 0.1f;
        CarRoad.setSpeed(CurrCarSpeed);
    }
    public void Decelerate()
    {
        CurrCarSpeed -= 0.1f;
        CarRoad.setSpeed(CurrCarSpeed);
    }
}
