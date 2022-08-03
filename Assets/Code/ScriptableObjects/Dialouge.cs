using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversation", menuName = "Dialogue/Main")]
public class Dialouge : ScriptableObject
{
    public DialogueSentence[] Sentences;
    public string CharacterName;
    public Sprite Portrait;
}
