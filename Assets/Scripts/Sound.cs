using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{ 
    public string Name;
    public AudioClip clip;
    [Range (0f,1f)]
    public float volume =1f;
    [Range (0.1f,3f)]
    public float pitch =1.0f;
    public bool loop ;
    [HideInInspector]
    public AudioSource audioSource; 

}
