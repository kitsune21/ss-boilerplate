using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameStates CurrentState { get; private set; }

    public static event Action<GameStates> OnGameStateChanged;

    void Awake() {
        UpdateGameState(GameStates.InGame);
    }

    public void UpdateGameState(GameStates newState) {
        CurrentState = newState;

        switch(newState) {
            case GameStates.MainMenu:
                break;
            case GameStates.InMenu:
                break;
            case GameStates.InGame:
                break;
            case GameStates.InDialogue:
                break;
            case GameStates.GamePaused:
                break;
            case GameStates.Victory:
                break;
            case GameStates.GameOver:
                break;
            case GameStates.PlayerDied:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
}
