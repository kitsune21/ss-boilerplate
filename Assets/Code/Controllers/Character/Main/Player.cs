using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player playerInstance;
    public SystemsController sc;
    public PlayerCharacterMovement pcm; 
    public PlayerStateMachine psm;
    public PlayerAnimationController pac;

    void Awake() {
        if(playerInstance != null && playerInstance != this) {
            Destroy(this);
        } else {
            playerInstance = this;
        }

        pcm = GetComponent<PlayerCharacterMovement>();
        psm = GetComponent<PlayerStateMachine>();
        pac = GetComponent<PlayerAnimationController>();
    }
}
