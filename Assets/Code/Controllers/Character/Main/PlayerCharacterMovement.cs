using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private TopDownPlayerController topDownController;
    private InputAction movement;
    [SerializeField] private float moveSpeed = 5f;
    private SystemsController systems;

    void Awake() {
      topDownController = new TopDownPlayerController();
      rb = GetComponent<Rigidbody2D>();
      systems = SystemsController.Instance;
    }

    void Start() {
      player = Player.Instance;
    }

    private void OnEnable() {
      movement = topDownController.Character.Movement;
      movement.Enable();
    }

    private void OnDisable() {
      movement.Disable();
    }

    private void FixedUpdate() {
      if(systems.State.CurrentState == GameStates.InGame) {
        rb.MovePosition(rb.position + movement.ReadValue<Vector2>() * moveSpeed * Time.fixedDeltaTime);
      }
    }

    public Vector2 GetMovement() {
      return movement.ReadValue<Vector2>();
    }
}
