using UnityEngine;
using UnityEngine.UI;

public class VolumeSetin : MonoBehaviour
{
    [SerializeField] private Slider musicMixer;
    [SerializeField] private Slider sfxMixer;
    [SerializeField] private Slider masterMixer;

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
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        if (audioManager != null)
        {
            float volume1 = musicMixer.value;
            audioManager.SetMusicVolume(volume1);
            PlayerPrefs.SetFloat("musicVolume", volume1);
        }      
    }

    public void SetSFXVolume()
    {
        if (audioManager != null)
        {
            float volume2 = sfxMixer.value;
            audioManager.SetSFXVolume(volume2);
            PlayerPrefs.SetFloat("SFXvolume", volume2);
        }
    }

    public void SetMasterVolume()
    {
        if (audioManager != null)
        {
            float volume3 = masterMixer.value;
            audioManager.SetMasterVolume(volume3);
            PlayerPrefs.SetFloat("masterVolume", volume3);
        }
    }

    private void LoadVolumes()
    {
        if (audioManager != null)
        {
            masterMixer.value = audioManager.GetMasterVolume();
            musicMixer.value = audioManager.GetMusicVolume();
            sfxMixer.value = audioManager.GetSFXVolume();


            musicMixer.value = PlayerPrefs.GetFloat("musicVolume");
            sfxMixer.value = PlayerPrefs.GetFloat("SFXvolume");
            masterMixer.value = PlayerPrefs.GetFloat("masterVolume");
        }
    }
}