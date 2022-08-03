using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public CharStates CurrentState { get; private set; }
    private PlayerCharacterMovement pcm;
    private Vector2 movement;
    public static event Action<CharStates> OnCharStateChanged;
    private SystemsController systems;

    void Awake() {
        updateState(CharStates.Idle_Down);
    }
    void Start() {
        pcm = GetComponent<PlayerCharacterMovement>();
        systems = SystemsController.Instance;
    }

    void Update() {
        if(systems.State.CurrentState == GameStates.InGame) {
            movement = pcm.GetMovement();
            calculateNewState();
        }
    }

    private void calculateNewState() {
        if(movement == Vector2.zero) {
            if(CurrentState == CharStates.Walk_Top) {
                updateState(CharStates.Idle_Top);
            }
            if(CurrentState == CharStates.Walk_Down) {
                updateState(CharStates.Idle_Down);
            }
            if(CurrentState == CharStates.Walk_Left) {
                updateState(CharStates.Idle_Left);
            }
            if(CurrentState == CharStates.Walk_Right) {
                updateState(CharStates.Idle_Right);
            }
        }
        if(movement.x > 0) {
            updateState(CharStates.Walk_Right);
        } else if(movement.x < 0) {
            updateState(CharStates.Walk_Left);
        } else if(movement.y > 0) {
            updateState(CharStates.Walk_Top);
        } else if(movement.y < 0) {
            updateState(CharStates.Walk_Down);
        }   
    }

    private void updateState(CharStates newState) {
        CurrentState = newState;

        OnCharStateChanged?.Invoke(newState);
    }
}
