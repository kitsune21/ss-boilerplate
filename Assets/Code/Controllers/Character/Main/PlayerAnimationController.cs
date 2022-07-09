using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Player player;
    private Animator animator;
    private PlayerStateMachine psm;
    private CharStates currentState;

    void Start() {
        player = Player.playerInstance;
        animator = GetComponentInChildren<Animator>();
        psm = GetComponent<PlayerStateMachine>();
    }

    void FixedUpdate() {
        if(player.sc.gsm.getState() != GameStates.GamePaused) {
            currentState = psm.getState();
            ChangeAnimationState();
        }
    }

    void ChangeAnimationState()
    {
        animator.Play(currentState.ToString());
    }

    public CharStates getState() {
        return currentState;
    }
}
