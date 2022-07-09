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
    public float moveSpeed = 5f;

    void Awake() {
      topDownController = new TopDownPlayerController();
      rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
      player = Player.playerInstance;
    }

    private void OnEnable() {
      movement = topDownController.Character.Movement;
      movement.Enable();
    }

    private void OnDisable() {
      movement.Disable();
    }

    private void FixedUpdate() {
      if(player.sc.gsm.getState() != GameStates.GamePaused) {
        rb.MovePosition(rb.position + movement.ReadValue<Vector2>() * moveSpeed * Time.fixedDeltaTime);
      }
    }

    public Vector2 getMovement() {
      return movement.ReadValue<Vector2>();
    }
}
