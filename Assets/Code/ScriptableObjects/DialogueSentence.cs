using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSentence", menuName = "Dialogue/Dialouge Sentence")]

public class DialogueSentence : ScriptableObject
{
    public int id;
    public DialogueType type;
    [TextArea(3,10)]
    public string sentence;
    public string[] questions;
    [TextArea(3,10)]
    public string[] responses;
}
