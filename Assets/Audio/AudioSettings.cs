using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;

    const string MIXER_MUSIC = "MusicVolume";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }
    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20 );

    }
}
