using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumnSetting : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    const string MUSIC = "BGMVolumn";
    const string SFXMixer = "SFXVolumn";
    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolumn);
        sfxSlider.onValueChanged.AddListener(SetSFXVolumn);
    }

    void SetMusicVolumn(float value)
    {
        mixer.SetFloat(MUSIC, Mathf.Log10(value) * 20);
        
    }
    void SetSFXVolumn(float value)
    {
        mixer.SetFloat(SFXMixer, Mathf.Log10(value) * 20);
    }
}
