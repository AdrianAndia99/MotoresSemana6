using UnityEngine;
using UnityEngine.Audio;

public class ManagerAudio : MonoBehaviour
{
    public static ManagerAudio Instance { get; private set; }

    [SerializeField] private AudioMixer mixer;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;
    private float masterVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        mixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        mixer.SetFloat("master", Mathf.Log10(volume) * 20);
    }
    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }
}
// se supone que sería el singleton pero no se como meterlo XDDDD 26-04-2024
// ahora si logre implementarlo gaaaaaaaaaa 27-04-2024