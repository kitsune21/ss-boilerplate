using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private TMP_Text text;

    public void UpdateTextAndImage(ItemInstance itemInstance) {
        image.sprite = itemInstance.MyItem.UiImage;
        text.text = itemInstance.Quantity.ToString();
    }

    public void UpdateText(int amount) {
        text.text = amount.ToString();
    }
}
