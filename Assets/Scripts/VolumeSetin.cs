using UnityEngine;
using UnityEngine.UI;

public class VolumeSetin : MonoBehaviour
{
    [SerializeField] private Slider sliderMixer;
    [SerializeField] private Slider sliderMixer2;

    private ManagerAudio audioManager;

    private void Start()
    {
        audioManager = ManagerAudio.Instance;

        if (audioManager != null)
        {
            LoadVolumes();
        }

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
        if (audioManager != null)
        {
            float volume = sliderMixer.value;
            audioManager.SetMusicVolume(volume);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }      
    }

    public void SetSFXVolume()
    {
        if (audioManager != null)
        {
            float volume = sliderMixer2.value;
            audioManager.SetSFXVolume(volume);
            PlayerPrefs.SetFloat("SFXvolume", volume);
        }
    }

    private void LoadVolumes()
    {
        if (audioManager != null)
        {
            sliderMixer.value = audioManager.GetMusicVolume();
            sliderMixer2.value = audioManager.GetSFXVolume();
            sliderMixer.value = PlayerPrefs.GetFloat("musicVolume");
            sliderMixer2.value = PlayerPrefs.GetFloat("SFXvolume");

        }
    }
}