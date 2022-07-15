using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestInventory
{
    
    [MenuItem("Test/Inventory/Add Sword")]
    public static void testAddSword() {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.id = 2;
        newItem.name = "Sword";
        newItem.description = "The master sword to seal away evil.";
        newItem.stackable = false;
        newItem.maxStack = 1;
        newItem.type = ItemTypes.unique;

        ItemInstance newItemInstance = ScriptableObject.CreateInstance<ItemInstance>();
        newItemInstance.myItem = newItem;
        newItemInstance.quantity = 1;

        Player.playerInstance.pi.addItemToInventory(newItemInstance);
    }

    [MenuItem("Test/Inventory/Add 1 Coins")]
    public static void testAdd1Coins() {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.id = 3;
        newItem.name = "Coin";
        newItem.description = "Just a gold coin.";
        newItem.stackable = true;
        newItem.maxStack = 6;
        newItem.type = ItemTypes.currency;

        ItemInstance newItemInstance = ScriptableObject.CreateInstance<ItemInstance>();
        newItemInstance.myItem = newItem;
        newItemInstance.quantity = 1;

        Player.playerInstance.pi.addItemToInventory(newItemInstance);
    }

    [MenuItem("Test/Inventory/Add 5 Coins")]
    public static void testAdd5Coins() {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.id = 3;
        newItem.name = "Coin";
        newItem.description = "Just a gold coin.";
        newItem.stackable = true;
        newItem.maxStack = 6;
        newItem.type = ItemTypes.currency;

        ItemInstance newItemInstance = ScriptableObject.CreateInstance<ItemInstance>();
        newItemInstance.myItem = newItem;
        newItemInstance.quantity = 5;

        Player.playerInstance.pi.addItemToInventory(newItemInstance);
    }

    [MenuItem("Test/Inventory/Log Inventory")]
    public static void logInventory() {
        Player.playerInstance.pi.logInventory();
    }
}
