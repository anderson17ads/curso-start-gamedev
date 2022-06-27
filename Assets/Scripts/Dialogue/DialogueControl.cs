using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObject;

    public Image actorProfileImage;

    public Text sentenceText;

    public Text actorNameText;

    private Player player;

    [Header("Settings")]
    public float typingSpeed;

    private bool _isShowing;

    private int index;

    private string[] sentences;

    private string[] actorNames;

    private Sprite[] actorProfiles;

    public static DialogueControl instance;

    public bool isShowing
    {
        get { return _isShowing; }
        set { _isShowing = value; }
    }

    private void Start() 
    {
        player = FindObjectOfType<Player>();    
    }

    private void Awake() 
    {
        instance = this;
    }

    public void speech(string[] txt, Sprite[] actorProfile, string[] actorName)
    {
        if (txt.Length == 0) {
            return;
        }

        if (!_isShowing) {
            dialogueObject.SetActive(true);
            
            sentences = txt;
            actorNames = actorName;
            actorProfiles = actorProfile;

            actorProfileImage.sprite = actorProfiles[index];
            actorNameText.text = actorNames[index];
            StartCoroutine(typeSentence());

            _isShowing = true;
        }

        if (_isShowing) {
            player.isPause = true;
            nextSentence();
        }
    }

    public void nextSentence()
    {
        if (sentenceText.text == sentences[index]) {
            sentenceText.text = "";

            if (index < sentences.Length -1) {
                index++;
                
                actorProfileImage.sprite = actorProfiles[index];
                actorNameText.text = actorNames[index];
                StartCoroutine(typeSentence());
                return;
            }

            resetSentence();
        }
    }

    public void resetSentence()
    {
        index = 0;
        dialogueObject.SetActive(false);
        sentences = null;
        _isShowing = false;
        player.isPause = false;

        sentenceText.text = "";
    }

    IEnumerator typeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray()) {
            sentenceText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
