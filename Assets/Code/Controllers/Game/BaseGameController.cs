using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseGameController : MonoBehaviour
{
    public SystemsController systems;
    private TopDownPlayerController controller;
    public GameObject inGameMenuPanel;
    private void Awake() {
        controller = new TopDownPlayerController();
    }

    void Start() {
        inGameMenuPanel.SetActive(false);
    }

    private void OnEnable() {
      controller.Menu.OpenCloseMenu.performed += OpenMenu;
      controller.Menu.OpenCloseMenu.Enable();
    }

    private void OnDisable() {
        controller.Menu.OpenCloseMenu.Disable();
    }

    private void OpenMenu(InputAction.CallbackContext obj) {{
        if(systems.gsm.getState() == GameStates.InGame || systems.gsm.getState() == GameStates.GamePaused) {
            if(inGameMenuPanel.activeSelf) {
                inGameMenuPanel.SetActive(false);
                systems.gsm.setStateInGame();
            } else {
                inGameMenuPanel.SetActive(true);
                systems.gsm.setStateGamePaused();
            }
        }
    }}

    public void quitGameButton() {
        Application.Quit();
    }
}
