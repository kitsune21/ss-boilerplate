using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Item")]
public class Item : ScriptableObject
{
    public int Id;
    public string ItemName;
    [TextArea(3,10)]
    public string Description;
    public ItemTypes Type;
    public bool Stackable;
    public int MaxStack;
    public Sprite UiImage;
    public Sprite GameImage;
}
