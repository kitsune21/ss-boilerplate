using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private TMP_Text text;

    public void updateTextAndImage(ItemInstance itemInstance) {
        image.sprite = itemInstance.myItem.uiImage;
        text.text = itemInstance.quantity.ToString();
    }

    public void updateText(int amount) {
        text.text = amount.ToString();
    }
}
