using UnityEngine;

public class SettingManager : MonoBehaviour
{
    private int controls;
    
    public void BtnKeys()
    {
        controls = 1;
        PlayerPrefs.SetInt("CurrControls",controls);
    }

    public void BtnButton()
    {
        controls = 2;
        PlayerPrefs.SetInt("CurrControls", controls);
    }

    public void BtnSensor()
    {
        controls = 3;
        PlayerPrefs.SetInt("CurrControls", controls);
    }

    public void BtnTouch()
    {
        controls = 4;
        PlayerPrefs.SetInt("CurrControls", controls);
    }

    public void MusicBtn()
    {
        AudioManager.instance.ToggleMusic();
    }
}
