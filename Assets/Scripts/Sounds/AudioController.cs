using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusic;

    // private AudioManager audioManager;

    void Start()
    {
        AudioManager.instance.onChangeAudioClip(backgroundMusic);
    }
}
