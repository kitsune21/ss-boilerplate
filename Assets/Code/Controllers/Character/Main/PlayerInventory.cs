using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryEntry> inventory = new List<InventoryEntry>();

    public void addItemToInventory(Item newItem) {
        
        if(newItem.stackable) {
            bool added = false;
            int amountLeft = 0;
            InventoryEntry addWithLeftover = null;
            foreach(InventoryEntry entry in inventory) {
                if(entry.MyItem.id == newItem.id) {
                    if(entry.CurrentAmount < entry.MyItem.maxStack) {
                        if(entry.CurrentAmount + newItem.quantity <= entry.MyItem.maxStack) {
                            entry.CurrentAmount += newItem.quantity;
                            added = true;
                            return;
                        } else if(entry.CurrentAmount + newItem.quantity > entry.MyItem.maxStack) {
                            amountLeft = entry.CurrentAmount + newItem.quantity - entry.MyItem.maxStack;
                            entry.CurrentAmount = entry.MyItem.maxStack;
                            newItem.quantity = amountLeft;
                            addWithLeftover = createEntry(newItem);
                            added = true;
                        }
                    }
                } 
            }
            if(!added) {
                inventory.Add(createEntry(newItem));
            }
            if(addWithLeftover != null) {
                inventory.Add(addWithLeftover);
            }
        } else {
            inventory.Add(createEntry(newItem));
        }
    }

    private InventoryEntry createEntry(Item newItem) {
        InventoryEntry newEntry = new InventoryEntry();
        newEntry.MyItem = newItem;
        newEntry.CurrentAmount = newItem.quantity;
        return newEntry;
    }

    public void logInventory() {
        foreach(InventoryEntry item in inventory) {
            Debug.Log("Item: " + item.MyItem.name + " Amount: " + item.CurrentAmount );
        }
    }
}
