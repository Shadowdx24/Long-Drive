using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void CarGarage()
    {
        SceneManager.LoadScene(2);
        //Time.timeScale = 1.0f;
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
