using UnityEngine;
using EasyUI.Toast;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    private int controls;
    [SerializeField]private Button Music;
    [SerializeField] Sprite SoundOn;
    [SerializeField] Sprite SoundOff;

    private void OnEnable()
    {
        SoundUI();
    }
    private void OnDisable()
    {
        
    }
    public void BtnKeys()
    {
        controls = 1;
        PlayerPrefs.SetInt("CurrControls",controls);
        Toast.Show("<color=white>Enable Keys</color>", 3f, ToastColor.Purple, ToastPosition.BottomCenter);
    }

    public void BtnButton()
    {
        controls = 2;
        PlayerPrefs.SetInt("CurrControls", controls);
        Toast.Show("<color=white>Enable Button</color>", 3f, ToastColor.Purple, ToastPosition.BottomCenter);
    }

    public void BtnSensor()
    {
        controls = 3;
        PlayerPrefs.SetInt("CurrControls", controls);
        Toast.Show("<color=white>Enable Sensor</color>", 3f, ToastColor.Purple, ToastPosition.BottomCenter);
    }

    public void BtnTouch()
    {
        controls = 4;
        PlayerPrefs.SetInt("CurrControls", controls);
        Toast.Show("<color=white>Enable Touch</color>", 3f, ToastColor.Purple, ToastPosition.BottomCenter);
    }

    public void MusicBtn()
    {
        AudioManager.instance.ToggleMusic();
        SoundUI();
    }
    public void SoundUI()
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
