using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestInventory
{
    
    [MenuItem("Test/Inventory/Add Sword")]
    public static void testAddSword() {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.Id = 2;
        newItem.ItemName = "Sword";
        newItem.Description = "The master sword to seal away evil.";
        newItem.Stackable = false;
        newItem.MaxStack = 1;
        newItem.Type = ItemTypes.unique;

        ItemInstance newItemInstance = ScriptableObject.CreateInstance<ItemInstance>();
        newItemInstance.MyItem = newItem;
        newItemInstance.Quantity = 1;

        Player.Instance.Inventory.AddItemToInventory(newItemInstance);
    }

    [MenuItem("Test/Inventory/Add 1 Coins")]
    public static void testAdd1Coins() {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.Id = 3;
        newItem.ItemName = "Coin";
        newItem.Description = "Just a gold coin.";
        newItem.Stackable = true;
        newItem.MaxStack = 6;
        newItem.Type = ItemTypes.currency;

        ItemInstance newItemInstance = ScriptableObject.CreateInstance<ItemInstance>();
        newItemInstance.MyItem = newItem;
        newItemInstance.Quantity = 1;

        Player.Instance.Inventory.AddItemToInventory(newItemInstance);
    }

    [MenuItem("Test/Inventory/Add 5 Coins")]
    public static void testAdd5Coins() {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.Id = 3;
        newItem.ItemName = "Coin";
        newItem.Description = "Just a gold coin.";
        newItem.Stackable = true;
        newItem.MaxStack = 6;
        newItem.Type = ItemTypes.currency;

        ItemInstance newItemInstance = ScriptableObject.CreateInstance<ItemInstance>();
        newItemInstance.MyItem = newItem;
        newItemInstance.Quantity = 5;

        Player.Instance.Inventory.AddItemToInventory(newItemInstance);
    }

    [MenuItem("Test/Inventory/Log Inventory")]
    public static void logInventory() {
        Player.Instance.Inventory.LogInventory();
    }
}
