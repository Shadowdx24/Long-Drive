using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast;

public class SettingManager : MonoBehaviour
{
    private int controls;
    [SerializeField] private Button Music;
    [SerializeField] private Sprite SoundOn;
    [SerializeField] private Sprite SoundOff;

    private void OnEnable()
    {
        UpdateSoundUI();
    }
    
    public void BtnKeys()
    {
        AudioManager.instance.Play("BtnClick");
        controls = 1;
        PlayerPrefs.SetInt("CurrControls",controls);
        Toast.Show("<color=white>Enable Keys</color>",3f,ToastColor.Blue);
    }

    public void BtnButton()
    {
        AudioManager.instance.Play("BtnClick");
        controls = 2;
        PlayerPrefs.SetInt("CurrControls", controls);
        Toast.Show("<color=white>Enable Button</color>",3f, ToastColor.Blue);
    }

    public void BtnSensor()
    {
        AudioManager.instance.Play("BtnClick");
        controls = 3;
        PlayerPrefs.SetInt("CurrControls", controls);
        Toast.Show("<color=white>Enable Sensor</color>",3f, ToastColor.Blue);
    }

    public void BtnTouch()
    {
        controls = 4;
        PlayerPrefs.SetInt("CurrControls", controls);
        Toast.Show("<color=white>Enable Touch</color>",3f, ToastColor.Blue);
    }

    public void MusicBtn()
    {
        AudioManager.instance.Play("BtnClick");
        AudioManager.instance.ToggleMusic();
        UpdateSoundUI();
    }

    public void UpdateSoundUI()
    {
        if (AudioManager.instance.isMuted)
        {
            Music.image.sprite = SoundOff;
        }
        else
        {
            Music.image.sprite = SoundOn;
        }
    }
}
