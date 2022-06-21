using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigLanguage : MonoBehaviour
{
    public enum languages {
        portuguese,
        english,
        spanish
    }

    public static ConfigLanguage instance;

    public languages language;

    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        // Portuguese default
        language = languages.portuguese;
    }
}
