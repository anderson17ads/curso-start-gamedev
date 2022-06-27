using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public DialogueSettings dialogueSettings;
    
    public LayerMask playerLayer;

    public float dialogueRange;

    private bool playerHit;

    private List<string> sentences = new List<string>();

    private List<string> actorNames = new List<string>();

    private List<Sprite> actorProfiles = new List<Sprite>();

    private void Start() {
        getDialogues();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && playerHit) {
            DialogueControl.instance.speech(
                sentences.ToArray(),
                actorProfiles.ToArray(), 
                actorNames.ToArray()
            );
        }
    }

    void FixedUpdate()
    {
        showDialogue();
    }

    private void showDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        playerHit = false;

        if (hit != null) {
            playerHit = true;
        }

        if (!playerHit) {
            DialogueControl.instance.resetSentence(); 
        }
    }

    private void getDialogues()
    {
        for(int i = 1; i < dialogueSettings.dialogues.Count; i++) {
            actorProfiles.Add(dialogueSettings.dialogues[i].profile);
            actorNames.Add(dialogueSettings.dialogues[i].actorName);
            sentences.Add(handleSentenceLanguage(i));
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

    private string handleSentenceLanguage(int index)
    {
        string value = "";

        switch (ConfigLanguage.instance.language) {
            case ConfigLanguage.languages.portuguese:
                value = dialogueSettings.dialogues[index].sentence.portuguese;
                break;
            case ConfigLanguage.languages.english:
                value = dialogueSettings.dialogues[index].sentence.english;
                break;
            case ConfigLanguage.languages.spanish:
                value = dialogueSettings.dialogues[index].sentence.spanish;
                break;
        }

        return value;
    }
}
