using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

// PURPOSE: This script will allow us to add audio clips and play them when the function is called

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
        }
    }

   public void Play (string name)
    {
        // Search the array to find the corresponding sound file
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Play the sound
        s.source.Play();
    }
}
