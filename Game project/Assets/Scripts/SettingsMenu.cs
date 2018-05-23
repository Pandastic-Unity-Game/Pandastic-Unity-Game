﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer Mixer;
    public Slider Master;
    public Slider Music;
    public Slider Sounds;

    public Toggle FullScreen;
    public Dropdown ResDropDown;
    Resolution[] resolutions;

    public Dropdown Quality;

    // Use this for initialization
    void Start () {
        resolutions = Screen.resolutions;
        ResDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        ResDropDown.AddOptions(options);
        ResDropDown.value = currentResIndex;
        ResDropDown.RefreshShownValue();

        Master.value = PlayerPrefs.GetFloat("MainVolume");
        Music.value = PlayerPrefs.GetFloat("MusicVolume");
        Sounds.value = PlayerPrefs.GetFloat("SoundVolume");

        Quality.value = PlayerPrefs.GetInt("Quality");
        FullScreen.isOn = (PlayerPrefs.GetInt("FullScreen") != 0);
    }

    public void SetMasterVolume(float volume)
    {
        Mixer.SetFloat("Master", volume);
        PlayerPrefs.SetFloat("MainVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        Mixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSoundVolume(float volume)
    {
        Mixer.SetFloat("Sounds", volume);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", (isFullScreen ? 1 : 0));
    }

    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
