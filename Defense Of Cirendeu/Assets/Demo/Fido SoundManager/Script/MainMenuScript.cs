using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [Header("Setting Menu")]
    public GameObject settingMenu;
    public SettingScript settingScript; // Referensi ke SettingScript

    // Start is called before the first frame update
    void Start()
    {
        settingMenu.SetActive(false);

        // Mengambil referensi SettingScript dari GameObject SettingMenu
        settingScript = settingMenu.GetComponent<SettingScript>();

        // Memperbarui nilai audioSlider.value saat MainMenuScript dimulai
        if (settingScript != null && settingScript.audioSlider != null)
        {
            settingScript.audioSlider.value = PlayerPrefs.GetFloat("audiovolume", settingScript.sliderValue);
        }
    }

    public void OpenSettingMenu() {
        settingMenu.SetActive(true);
        SoundManager.instance.PlaySFX(0);
    }

    public void CloseSettingMenu() { 
        settingMenu.SetActive(false);
        SoundManager.instance.PlaySFX(0);
    }
}
