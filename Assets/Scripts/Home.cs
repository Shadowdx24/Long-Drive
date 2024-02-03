using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject settingsObj;
    
    public void GameStart()
    {
        AudioManager.instance.Play("BtnClick");
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        AudioManager.instance.Stop("Home");
        AudioManager.instance.Play("CarBg");
    }

    public void CarGarage()
    {
        AudioManager.instance.Play("BtnClick");
        SceneManager.LoadScene(2);
    }

    public void RoadGarage()
    {
        AudioManager.instance.Play("BtnClick");
        SceneManager.LoadScene(3);
    }

    public void GameQuit()
    {
        AudioManager.instance.Play("BtnClick");
        Application.Quit();
    }

    public void GameSetting()
    {
        AudioManager.instance.Play("BtnClick");
        settingsObj.SetActive(true);
    }

    public void GameHome()
    {
        AudioManager.instance.Play("BtnClick");
        settingsObj.SetActive(false);
    }
}
