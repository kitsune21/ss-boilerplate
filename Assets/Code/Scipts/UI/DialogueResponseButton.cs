using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueResponseButton : MonoBehaviour
{
    private TMP_Text myText;
    private int index;

    public void setResponseText(string question, int newIndex) {
        myText = GetComponentInChildren<TMP_Text>();
        myText.text = (newIndex + 1) + ") " + question;
        index = newIndex;
    }

    public int getIndex() {
        return index;
    }
}
