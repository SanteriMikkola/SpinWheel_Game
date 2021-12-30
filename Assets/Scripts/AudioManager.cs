using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private Transform scrollBar;

    private Scrollbar scrollbar;

    private Transform audioManager;

    private AudioSource audioS;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Start()
    {
        Play("Music");

        audioManager = GameObject.Find("AudioManager").transform;

        scrollBar = GameObject.Find("Scrollbar").transform;

        scrollbar = scrollBar.gameObject.GetComponent<Scrollbar>();
        audioS = audioManager.gameObject.GetComponent<AudioSource>();
        scrollbar.value = audioS.volume;
    }

    public void ChangeMusicVolume(float volume)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == "Music");

        s.source.volume = volume;
        s.volume = volume;
    }

    public void ChangeSoundVolume(float volume)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == "Win");

        s.source.volume = volume;
        s.volume = volume;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        s.source.Play();
    }
}
