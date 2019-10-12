using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer volumeMixer;
    public Slider volumeSlider;

    public void SetVolume(float volume)
    {
        Debug.Log(volume);

        volumeMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);

        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}

//Mathf.Log10(volume) * 20);