using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Renderer road;
    [SerializeField] public float speed=0.1f;
    private Vector2 offset;
    
    void Update()
    {
        offset=new Vector2(0,Time.time*speed);
        road.material.mainTextureOffset = offset;
    }

    public void setSpeed(float s)
    {
        speed = s;
    }
}
