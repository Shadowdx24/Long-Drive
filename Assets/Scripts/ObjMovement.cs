using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    void Update()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y - (speed * Time.deltaTime),transform.position.z);
    }
}
