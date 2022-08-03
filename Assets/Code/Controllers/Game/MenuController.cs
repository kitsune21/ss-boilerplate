using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    private SystemsController systems;
    private TopDownPlayerController controller;
    [SerializeField] private GameObject inGameMenuPanel;
    private void Awake() {
        systems = SystemsController.Instance;
        controller = new TopDownPlayerController();
        inGameMenuPanel.SetActive(true);
    }

    void Start() {
        inGameMenuPanel.SetActive(false);
    }

    void OnEnable() {
      controller.Menu.OpenCloseMenu.performed += OpenMenu;
      controller.Menu.OpenCloseMenu.Enable();
    }

    void OnDisable() {
        controller.Menu.OpenCloseMenu.Disable();
    }

    private void OpenMenu(InputAction.CallbackContext obj) {{
        if(systems.State.CurrentState == GameStates.InMenu) {
            inGameMenuPanel.SetActive(false);
            systems.State.UpdateGameState(GameStates.InGame);
            return;
        }
        if(systems.State.CurrentState == GameStates.InGame) {
            inGameMenuPanel.SetActive(true);
            systems.State.UpdateGameState(GameStates.InMenu);
            return;
        }
    }}
}
