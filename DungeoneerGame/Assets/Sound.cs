 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// PURPOSE: This class will allow us to set the name, volume and pitch of our audio clips

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string name;

    public float volume;

    [Range(0.5f, 1.5f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
