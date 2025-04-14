using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public static AudioManager Instance;
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
        PlayMusic("theme");
    }
    public void PlayMusic(string name)
    {
        AudioClip s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sounds not found.");
        }
        else
        {
            musicSource.clip = s;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        AudioClip s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sfx not found.");
        }
        else
        {
            sfxSource.PlayOneShot(s);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
