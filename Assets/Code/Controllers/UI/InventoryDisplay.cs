using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPanel;

    public GameObject addItemToInventoryDisplay(ItemInstance itemToAdd) {
        GameObject panelToAdd = Instantiate(itemPanel, transform.position, transform.rotation, transform);
        panelToAdd.GetComponent<ItemPanel>().updateTextAndImage(itemToAdd);
        return panelToAdd;
    }
}
