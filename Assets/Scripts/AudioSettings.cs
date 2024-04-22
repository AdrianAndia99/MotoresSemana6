using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioSettings", menuName = "Audio/AudioSettings")]
public class AudioSettings : ScriptableObject
{
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
}

