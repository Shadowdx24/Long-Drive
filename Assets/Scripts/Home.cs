using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] GameObject GameSettingScene;
    
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
        GameSettingScene.SetActive(true);
    }

    public void GameHome()
    {
        GameSettingScene.SetActive(false);
    }
}
