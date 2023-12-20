using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
