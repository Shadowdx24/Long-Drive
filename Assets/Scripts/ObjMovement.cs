using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    private float speed = 1f;
    
    void Update()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y - (speed * Time.deltaTime),transform.position.z);
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }
}
