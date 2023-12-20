using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateObj",0f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateObj()
    {
        int i=Random.Range(0,Objects.Length);
        float x = Random.Range(-2.3f,2.3f);
        float y = this.transform.position.y;
        GameObject enemyCar = Instantiate(Objects[i],new Vector2(x,y),Quaternion.identity,this.transform);
    }
}
