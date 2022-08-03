using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public PlayerCharacterMovement Movement { get; private set; }
    public PlayerStateMachine State { get; private set; }
    public PlayerAnimationController Animation { get; private set; }
    public PlayerInventory Inventory { get; private set; }

    void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }

        Movement = GetComponent<PlayerCharacterMovement>();
        State = GetComponent<PlayerStateMachine>();
        Animation = GetComponent<PlayerAnimationController>();
    }
}
