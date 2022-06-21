using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(DialogueSettings))]
public class DialogueBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings dialogueSettings = (DialogueSettings)target;

        // Languages
        DialogueLanguages dialogueLanguages = new DialogueLanguages();
        dialogueLanguages.portuguese = dialogueSettings.sentence;

        // Sentences
        DialogueSentences dialogueSentences = new DialogueSentences();
        dialogueSentences.profile = dialogueSettings.speakerSprite;
        dialogueSentences.sentence = dialogueLanguages;

        // Add dialogue
        if (GUILayout.Button("Create Dialogue")) {
            if (dialogueSettings.sentence != "") {
                dialogueSettings.dialogues.Add(dialogueSentences);

                // Empty Settings
                dialogueSettings.speakerSprite = null;
                dialogueSettings.sentence = "";
            }
        }
    }
}

#endif