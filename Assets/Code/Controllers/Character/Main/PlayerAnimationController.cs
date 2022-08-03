using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Player player;
    private Animator animator;
    private CharStates currentState;

    void Start() {
        player = Player.Instance;
        animator = GetComponentInChildren<Animator>();
        PlayerStateMachine.OnCharStateChanged += onCharStateChangedEvent;
    }

    private void OnDestroy() {
        PlayerStateMachine.OnCharStateChanged -= onCharStateChangedEvent;    
    }

    private void onCharStateChangedEvent(CharStates newState) {
        animator.Play(player.State.CurrentState.ToString());
    }
}
