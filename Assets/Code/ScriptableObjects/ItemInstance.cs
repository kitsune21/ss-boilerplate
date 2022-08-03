using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Instance")]

public class ItemInstance : ScriptableObject
{
    public int Id;
    public Item MyItem;
    public int Quantity;
}
