using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryEntry> inventory = new List<InventoryEntry>();
    [SerializeField]
    private InventoryDisplay inventoryDisplay;

    public void addItemToInventory(ItemInstance itemInstance) {
        
        if(itemInstance.myItem.stackable) {
            bool added = false;
            int amountLeft = 0;
            InventoryEntry addWithLeftover = null;
            foreach(InventoryEntry entry in inventory) {
                if(entry.MyItem.id == itemInstance.myItem.id) {
                    if(entry.CurrentAmount < entry.MyItem.maxStack) {
                        if(entry.CurrentAmount + itemInstance.quantity <= entry.MyItem.maxStack) {
                            entry.CurrentAmount += itemInstance.quantity;
                            entry.MyInventoryEntry.GetComponent<ItemPanel>().updateText(entry.CurrentAmount);
                            added = true;
                            return;
                        } else if(entry.CurrentAmount + itemInstance.quantity > entry.MyItem.maxStack) {
                            amountLeft = entry.CurrentAmount + itemInstance.quantity - entry.MyItem.maxStack;
                            entry.CurrentAmount = entry.MyItem.maxStack;
                            entry.MyInventoryEntry.GetComponent<ItemPanel>().updateText(entry.CurrentAmount);
                            itemInstance.quantity = amountLeft;
                            addWithLeftover = createEntry(itemInstance);
                            added = true;
                        }
                    }
                } 
            }
            if(!added) {
                inventory.Add(createEntry(itemInstance));
            }
            if(addWithLeftover != null) {
                inventory.Add(addWithLeftover);
            }
        } else {
            inventory.Add(createEntry(itemInstance));
        }
    }

    private InventoryEntry createEntry(ItemInstance itemInstance) {
        InventoryEntry newEntry = new InventoryEntry();
        newEntry.MyItem = itemInstance.myItem;
        newEntry.CurrentAmount = itemInstance.quantity;
        newEntry.MyInventoryEntry = inventoryDisplay.addItemToInventoryDisplay(itemInstance);
        return newEntry;
    }

    public void logInventory() {
        foreach(InventoryEntry item in inventory) {
            Debug.Log("Item: " + item.MyItem.name + " Amount: " + item.CurrentAmount );
        }
    }
}
