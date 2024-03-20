using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    [Header("Volume")]
    public AudioMixer audioMixer;
    public Slider audioSlider;
    public float sliderValue = 100f;

    [Header("SFX")]
    public Toggle onoffToggle;
    public string audioGroup = "SFX"; // Nama grup yang ingin Anda kontrol (Di Expose Parameter)

    // Start is called before the first frame update
    void Start()
    {
        audioSlider.value = PlayerPrefs.GetFloat("audiovolume", sliderValue);

        // Ambil nilai OnOff dari PlayerPrefs saat permainan dimulai
        bool isOn = PlayerPrefs.GetInt("OnOff", 1) == 1;
        onoffToggle.isOn = isOn;

        // Atur volume berdasarkan nilai OnOff saat permainan dimulai
        SetOnOffSFX(isOn);
    }

    public void SetVolume(float volume)
    {
        float mappedVolumeDB = Mathf.Lerp(-25f, 0f, volume / 100f);

        audioMixer.SetFloat("volume", mappedVolumeDB);
        sliderValue = volume;
        PlayerPrefs.SetFloat("audiovolume", sliderValue);
        PlayerPrefs.Save();
    }

    public void SetOnOffSFX(bool isOn)
    {
        // Ambil grup SFX dari grup Master
        AudioMixerGroup[] groups = audioMixer.FindMatchingGroups(audioGroup);
        if (groups.Length > 0)
        {
            AudioMixerGroup sfxGroup = groups[0];

            float volumeDB = isOn ? 0f : -80f;
            audioMixer.SetFloat(audioGroup, volumeDB);

            // Menyimpan nilai OnOff ke PlayerPrefs
            PlayerPrefs.SetInt("OnOff", isOn ? 1 : 0);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Grup Audio tidak ditemukan: " + audioGroup);
        }
    }
}
