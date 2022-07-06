using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject dialogueBox;
    public Text characterNameText;
    public Text dialougeText;
    private Animator anim;
    public float typingSpeed;

    void Awake()
    {
        sentences = new Queue<string>();
        anim = dialogueBox.GetComponent<Animator>();
    }

    public void loadDialogue(Dialouge dialouge) {
        anim.SetBool("isShow", true);
        sentences.Clear();
        foreach(string sentence in dialouge.sentences) {
            sentences.Enqueue(sentence);
        }

        characterNameText.text = dialouge.characterName;

        displayNextSentence();
    }

    public void displayNextSentence() {
        if(sentences.Count == 0) {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(writeSentence(sentence));
    }

    private void endDialogue() {
        anim.SetBool("isShow", false);
    }

    private IEnumerator writeSentence(string sentence) {
        dialougeText.text = "";

        foreach(char letter in sentence.ToCharArray()) {
            dialougeText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
