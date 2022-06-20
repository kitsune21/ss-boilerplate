using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultableText : MonoBehaviour
{
    private Text myText;
    private string myTextDefaultString;

    void Start()
    {
        myText = GetComponent<Text>();
        myTextDefaultString = myText.text;
    }

    public void updateText(string newText) {
        myText.text = myTextDefaultString + newText;
    }
}
