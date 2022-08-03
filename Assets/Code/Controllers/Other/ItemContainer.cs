using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private ItemInstance myItemInstance;

    public ItemInstance OpenContainer() {
        return myItemInstance;
    }
}
