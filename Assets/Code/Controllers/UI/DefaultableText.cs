using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefaultableText : MonoBehaviour
{
    private TMP_Text myText;
    private string myTextDefaultString;

    void Awake()
    {
        myText = GetComponent<TMP_Text>();
        myTextDefaultString = myText.text;
    }

    public void UpdateText(string newText) {
        myText.text = myTextDefaultString + newText;
    }
}
