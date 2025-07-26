using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private Slider sliderVolumeMusic;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float musicVolume;
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

    private void Start()
    {
        LoadAudioSettings();
        ValueMusic();
    }

    public void SliderMusic()
    {
        musicVolume = sliderVolumeMusic.value;
        Save();
        ValueMusic();
    }

    private void ValueMusic()
    {
        audioSource.volume = musicVolume;
        sliderVolumeMusic.value = musicVolume;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", sliderVolumeMusic.value);
    }
    
    private void LoadAudioSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("volume", musicVolume);
    }
}