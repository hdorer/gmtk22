using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerMovement movement;
    PlayerDieRotation rotation;
    private bool canRotate;
    public bool CanRotate { set { canRotate = value; } }

    float oldHorizontal, oldVertical;

    [SerializeField] private UndoEvents undoEvents;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerDieRotation>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        foreach(KeyCode code in Enum.GetValues(typeof(KeyCode))) {
            if(Input.GetKeyDown(code)) {
                Debug.Log("key: " + code);
            }
        }

        // temporary movement code
        if(verticalDown(vertical)) {
            if (movement.move(0, (int)Mathf.Sign(vertical))) {
                rotation.rotateOnMove(0, (int)Mathf.Sign(vertical));
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        if(horizontalDown(horizontal)) {
            if (movement.move((int)Mathf.Sign(horizontal), 0)) {
                rotation.rotateOnMove((int)Mathf.Sign(horizontal), 0);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        
        if (Input.GetButtonDown("RotateL") && canRotate) {
            rotation.RotateCounterClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }
        if (Input.GetButtonDown("RotateR") && canRotate) {
            rotation.RotateClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }

        if(Input.GetButtonDown("Undo")) {
            undoEvents.undoLastMoveEvent.Invoke();
            movement.undoLastMove();
            rotation.undoLastMove();
        }
        if(Input.GetButtonDown("Restart")) {
            undoEvents.restart();
        }

        oldHorizontal = horizontal;
        oldVertical = vertical;
    }

    private void NextTurn()
    {
        rotation.getActiveFace();

    }

    private bool horizontalDown(float horizontal) {
        if(horizontal != 0 && oldHorizontal == 0) {
            return true;
        }
        return false;
    }

    private bool verticalDown(float vertical) {
        if(vertical != 0 && oldVertical == 0) {
            return true;
        }
        return false;
    }
}
