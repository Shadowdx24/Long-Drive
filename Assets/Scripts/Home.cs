using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject settingsObj;
    
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        AudioManager.instance.Stop("Home");
        AudioManager.instance.Play("CarBg");
    }

    public void CarGarage()
    {
        SceneManager.LoadScene(2);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameSetting()
    {
        settingsObj.SetActive(true);
    }

    public void GameHome()
    {
        settingsObj.SetActive(false);
    }
}
