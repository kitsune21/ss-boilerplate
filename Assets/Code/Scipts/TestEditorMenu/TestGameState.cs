using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestGameState
{
    [MenuItem("Test/Game State/Main Menu")]
    public static void testStateUpdateMainMenu() {
        SystemsController.Instance.State.UpdateGameState(GameStates.MainMenu);
    }

    [MenuItem("Test/Game State/In Game")]
    public static void testStateUpdateInGame() {   
        SystemsController.Instance.State.UpdateGameState(GameStates.InGame);
    }

    [MenuItem("Test/Game State/In Menu")]
    public static void testStateUpdateInMenu() {
        SystemsController.Instance.State.UpdateGameState(GameStates.InMenu);
    }

    [MenuItem("Test/Game State/Game Paused")]
    public static void testStateUpdateGamePaused() {
        SystemsController.Instance.State.UpdateGameState(GameStates.GamePaused);
    }

    [MenuItem("Test/Game State/Player Died")]
    public static void testStateUpdatePlayerDied() {
        SystemsController.Instance.State.UpdateGameState(GameStates.PlayerDied);
    }

    [MenuItem("Test/Game State/Game Over")]
    public static void testStateUpdateGameOver() {
        SystemsController.Instance.State.UpdateGameState(GameStates.GameOver);
    }

    [MenuItem("Test/Game State/Victory")]
    public static void testStateUpdateVictory() {
        SystemsController.Instance.State.UpdateGameState(GameStates.Victory);
    }
}
