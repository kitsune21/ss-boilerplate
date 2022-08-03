using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSentence", menuName = "Dialogue/Dialouge Sentence")]

public class DialogueSentence : ScriptableObject
{
    public int Id;
    public DialogueType Type;
    [TextArea(3,10)]
    public string Sentence;
    public string[] Questions;
    [TextArea(3,10)]
    public string[] Responses;
}
