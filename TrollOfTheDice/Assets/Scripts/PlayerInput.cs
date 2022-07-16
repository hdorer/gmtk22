using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerMovement movement;
    PlayerDieRotation rotation;
    private bool canRotate;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerDieRotation>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // temporary movement code
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if(movement.move(0, 1)) {
                rotation.rotateOnMove(0, 1);
            }
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            if(movement.move(0, -1)) {
                rotation.rotateOnMove(0, -1);
            }
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if(movement.move(-1, 0)) {
                rotation.rotateOnMove(-1, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if(movement.move(1, 0)) {
                rotation.rotateOnMove(1, 0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && canRotate) { rotation.RotateCounterClockwise(); }
        if (Input.GetKeyDown(KeyCode.E) && canRotate) { rotation.RotateClockwise(); }
    }

    public void EnableRotate() { canRotate = true; }
    public void DisableRotate() { canRotate = false; }

    private void NextTurn()
    {
        rotation.getActiveFace();

    }
}
