using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public Camera mainCamera;
    private StressReceiver cameraShaker;
    public Transform followTarget;
    private Vector3 target;
    private Vector2 direction;
    public float cameraPad = 1000;
    private float speed = 5;

    void Start() {
        direction = new Vector2();
        cameraShaker = mainCamera.GetComponent<StressReceiver>();
    }

    void FixedUpdate() {
        //updateDirection();
        Vector3 followTargetFrozenZ = new Vector3(followTarget.position.x, followTarget.position.y, -10);
        mainCamera.gameObject.transform.position = Vector3.MoveTowards(followTargetFrozenZ, mainCamera.gameObject.transform.position, Time.deltaTime * speed);
    }

    void updateDirection() {
        CharStates playerState = SystemsController.systemInstance.player.pac.getState();
        if(playerState == CharStates.Walk_Top) {
            direction = new Vector2(0, cameraPad);
        } else if(playerState == CharStates.Walk_Right) {
            direction = new Vector2(cameraPad, 0);
        } else if(playerState == CharStates.Walk_Down) {
            direction = new Vector2(0, -cameraPad);
        } else if(playerState == CharStates.Walk_Left) {
            direction = new Vector2(-cameraPad, 0);
        }
    }

    public void cameraShake(float intensity = 1f) {
        cameraShaker.InduceStress(intensity);
    }
}