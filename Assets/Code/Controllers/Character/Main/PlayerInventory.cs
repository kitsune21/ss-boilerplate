using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryEntry> inventory = new List<InventoryEntry>();
    [SerializeField] private InventoryDisplay inventoryDisplay;

    public void AddItemToInventory(ItemInstance itemInstance) {
        
        if(itemInstance.MyItem.Stackable) {
            bool added = false;
            int amountLeft = 0;
            InventoryEntry addWithLeftover = null;
            foreach(InventoryEntry entry in inventory) {
                if(entry.MyItem.Id == itemInstance.MyItem.Id) {
                    if(entry.CurrentAmount < entry.MyItem.MaxStack) {
                        if(entry.CurrentAmount + itemInstance.Quantity <= entry.MyItem.MaxStack) {
                            entry.CurrentAmount += itemInstance.Quantity;
                            entry.MyInventoryEntry.GetComponent<ItemPanel>().UpdateText(entry.CurrentAmount);
                            added = true;
                            return;
                        } else if(entry.CurrentAmount + itemInstance.Quantity > entry.MyItem.MaxStack) {
                            amountLeft = entry.CurrentAmount + itemInstance.Quantity - entry.MyItem.MaxStack;
                            entry.CurrentAmount = entry.MyItem.MaxStack;
                            entry.MyInventoryEntry.GetComponent<ItemPanel>().UpdateText(entry.CurrentAmount);
                            itemInstance.Quantity = amountLeft;
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
        newEntry.MyItem = itemInstance.MyItem;
        newEntry.CurrentAmount = itemInstance.Quantity;
        newEntry.MyInventoryEntry = inventoryDisplay.AddItemToInventoryDisplay(itemInstance);
        return newEntry;
    }

    public void LogInventory() {
        foreach(InventoryEntry item in inventory) {
            Debug.Log("Item: " + item.MyItem.name + " Amount: " + item.CurrentAmount );
        }
    }
}
