using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObject;

    public Image profileImage;

    public Text sentenceText;

    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    private bool _isShowing;

    private int index;

    private string[] sentences;

    public static DialogueControl instance;

    public bool isShowing
    {
        get { return _isShowing; }
        set { _isShowing = value; }
    }

    private void Awake() {
        instance = this;
    }

    public void speech(string[] txt)
    {
        if (txt.Length == 0) {
            return;
        }

        if (!_isShowing) {
            dialogueObject.SetActive(true);
            
            sentences = txt;

            StartCoroutine(typeSentence());

            _isShowing = true;
        }

        if (_isShowing) {
            nextSentence();
        }
    }

    public void nextSentence()
    {
        if (sentenceText.text == sentences[index]) {
            sentenceText.text = "";

            if (index < sentences.Length -1) {
                index++;
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
