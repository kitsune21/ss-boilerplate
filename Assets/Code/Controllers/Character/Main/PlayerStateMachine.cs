using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private CharStates state;
    private PlayerCharacterMovement pcm;
    private Vector2 movement;

    void Start() {
        pcm = GetComponent<PlayerCharacterMovement>();
    }

    void Awake() {
        state = CharStates.Idle_Down;
    }

    void Update() {
        movement = pcm.getMovement();
        updateState();
    }

    private void updateState() {
        if(movement == Vector2.zero) {
            if(state == CharStates.Walk_Top) {
                state = CharStates.Idle_Top;
            }
            if(state == CharStates.Walk_Down) {
                state = CharStates.Idle_Down;
            }
            if(state == CharStates.Walk_Left) {
                state = CharStates.Idle_Left;
            }
            if(state == CharStates.Walk_Right) {
                state = CharStates.Idle_Right;
            }
        }
        if(movement.y > 0) {
            state = CharStates.Walk_Top;
        } else if(movement.y < 0) {
            state = CharStates.Walk_Down;
        }
        if(movement.x > 0) {
            state = CharStates.Walk_Right;
        } else if(movement.x < 0) {
            state = CharStates.Walk_Left;
        }
    }

    public CharStates getState() {
        return state;
    }
}
