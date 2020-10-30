using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private AudioSource _musicSourse;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundsSlider;

    private float _musicVolume;
    private float _soundsVolume;

    private void Awake()
    {
        GetSoundSettings();
    }

    private void Start()
    {
        SetSoundsVolume();
    }

    private void SetSoundsVolume()
    {
        for (int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i].volume = _soundsVolume;
        }

        _musicSourse.volume = _musicVolume;
    }

    public void SwitchSoundState()
    {
        _musicVolume = _musicSlider.value;
        _soundsVolume = _soundsSlider.value;

        SaveSoundSettings();
        SetSoundsVolume();
    }

    public void TapSound(AudioClip audioClip)
    {
        _audioSources[0].clip = audioClip;
        _audioSources[0].Play();
    }

    public void EffectSound(AudioClip audioClip)
    {
        _audioSources[1].clip = audioClip;
        _audioSources[1].Play();
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
        PlayerPrefs.SetFloat("SoundVolume", _soundsVolume);
    }
    private void GetSoundSettings()
    {
        _musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        _soundsVolume = PlayerPrefs.GetFloat("SoundVolume");
    }
}
