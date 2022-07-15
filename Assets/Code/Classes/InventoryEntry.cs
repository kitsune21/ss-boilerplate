using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEntry
{
    private Item myItem;
    public Item MyItem { get; set; }
    private int currentAmount;
    public int CurrentAmount { get; set; }
    private GameObject myInventoryEntry;
    public GameObject MyInventoryEntry { get; set; }
}
