using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int controls;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
    public void MusicBtn()
    {
        AudioManager.instance.ToggleMusic();
    }
}
