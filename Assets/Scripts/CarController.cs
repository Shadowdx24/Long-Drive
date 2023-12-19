using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float rotationAngle = 1.0f;
    private bool goingLeft;
    private bool goingRight;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
