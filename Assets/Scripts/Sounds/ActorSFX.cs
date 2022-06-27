using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSFX : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }
    
    private void onPlayAudioClip(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
