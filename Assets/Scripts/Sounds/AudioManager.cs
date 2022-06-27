using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake() 
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
            return;
        }

        Destroy(gameObject);
    }

    public void onChangeAudioClip(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
