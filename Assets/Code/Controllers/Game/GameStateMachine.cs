using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private GameStates state;

    void Awake() {
        state = GameStates.InGame;
    }

    public GameStates getState() {
        return state;
    }

    public void setStateInGame() {
        state = GameStates.InGame;
    }

    public void setStateGamePaused() {
        state = GameStates.GamePaused;
    }

    public void setStateMainMenu() {
        state = GameStates.MainMenu;
    }
}
