using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Seetings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;

    public string sentence;
    
    public List<DialogueSentences> dialogues = new List<DialogueSentences>();
}