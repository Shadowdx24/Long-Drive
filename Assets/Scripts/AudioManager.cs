using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
       
        foreach (var sound in sounds)
        {
            sound.audioSource=gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip=sound.clip;
            sound.audioSource.loop=sound.loop;
            sound.audioSource.volume=sound.volume;
            sound.audioSource.pitch=sound.pitch;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Play("Home");
    }

    public void Play(string audioName) 
    {
        Sound s = Array.Find(sounds,sound=>sound.Name==audioName);
        if (s==null)
        {
            return;
        }
        s.audioSource.Play();

    }
    public void Stop(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == audioName);
        if (s == null)
        {
            return;
        }
        s.audioSource.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
