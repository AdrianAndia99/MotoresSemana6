using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetin : MonoBehaviour
{

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider sliderMixer;
    [SerializeField] private Slider sliderMixer2;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolumes();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = sliderMixer.value;
        mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = sliderMixer2.value;
        mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXvolume", volume);
    }

    private void LoadVolumes()
    {
        sliderMixer.value = PlayerPrefs.GetFloat("musicVolume");
        sliderMixer2.value = PlayerPrefs.GetFloat("SFXvolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}