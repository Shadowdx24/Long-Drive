using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Renderer road;
    [SerializeField] private float speed = 0.1f;
    private Vector2 offset;
    [SerializeField] private Material[] roadImages;
    public int currRoad;
    
    void Start()
    {
        currRoad = PlayerPrefs.GetInt("MainRoad");  
        road.material = roadImages[currRoad];
    }
    void Update()
    {
        offset=new Vector2(0,Time.time*speed);
        road.material.mainTextureOffset = offset;
        
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }
}
