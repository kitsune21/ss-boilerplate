using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversation", menuName = "Dialouge")]
public class Dialouge : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] sentences;
    [TextArea(3, 10)]
    public string[] responses;
    public DialogueType type;
    public string characterName;
    public Sprite portrait;
}
