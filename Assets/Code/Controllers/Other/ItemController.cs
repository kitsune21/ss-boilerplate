using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private ItemInstance myItemInstance;

    void Start() {
        gameObject.GetComponent<SpriteRenderer>().sprite = myItemInstance.myItem.gameImage;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Player.playerInstance.pi.addItemToInventory(myItemInstance);
            Destroy(gameObject);
        }
    }
}
