using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    [TextArea(3,10)]
    public string description;
    public ItemTypes type;
    public bool stackable;
    public int maxStack;
    public Sprite uiImage;
    public Sprite gameImage;
}
