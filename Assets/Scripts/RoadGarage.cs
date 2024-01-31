using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoadGarage : MonoBehaviour
{
    [SerializeField] private Image roadSelection;
    [SerializeField] private Sprite[] roadImages;
    [SerializeField] private GameObject settingObj;
    [SerializeField] private TextMeshProUGUI moneyText;
    private int roadIndex;
    private int moneyIndex;
    
    void Start()
    {
        roadIndex = 0;
        moneyIndex = PlayerPrefs.GetInt("Money");
        moneyText.text = "" + moneyIndex;
    }

    public void NextRoad()
    {
        AudioManager.instance.Play("BtnClick");
        roadIndex++;
        ShowRoad(roadIndex);
    }

    public void PrevRoad()
    {
        AudioManager.instance.Play("BtnClick");
        roadIndex--;
        ShowRoad(roadIndex);
    }

    private void ShowRoad(int roadNumber)
    {
        if (roadNumber > roadImages.Length -1)
        {
            roadNumber = 0;
        }
        else if(roadNumber < 0)
        {
            roadNumber = roadImages.Length -1;
        }

        roadIndex = roadNumber;
        roadSelection.sprite = roadImages[roadIndex];
        PlayerPrefs.SetInt("MainRoad", roadIndex);
    }

    public void GameStart()
    {
        AudioManager.instance.Play("BtnClick");
        AudioManager.instance.Play("CarBg");
        AudioManager.instance.Stop("Home");
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void GameHome()
    {
        AudioManager.instance.Play("BtnClick");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void GameSetting()
    {
        AudioManager.instance.Play("BtnClick");
        settingObj.SetActive(true);
    }
}
