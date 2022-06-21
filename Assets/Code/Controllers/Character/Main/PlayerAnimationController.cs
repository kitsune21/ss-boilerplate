using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerStateMachine psm;
    private CharStates currentState;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        psm = GetComponent<PlayerStateMachine>();
    }

    void FixedUpdate() {
        currentState = psm.getState();
        ChangeAnimationState();
    }

    void ChangeAnimationState()
    {
        animator.Play(currentState.ToString());
    }
}
