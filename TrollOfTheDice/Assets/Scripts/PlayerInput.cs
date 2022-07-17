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
    private bool lastActionWasUndo = false;
    public bool LastActionWasUndo {
        get {
            Debug.Log("LastActionWasUndo will return " + lastActionWasUndo);
            return lastActionWasUndo;
        }
    }

    private void Start() {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerDieRotation>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // temporary movement code
        if(verticalDown(vertical)) {
            lastActionWasUndo = false;
            Debug.Log("lastActionWasUndo set to: " + lastActionWasUndo);

            if(movement.move(0, (int)Mathf.Sign(vertical))) {
                NextTurn();
                rotation.rotateOnMove(0, (int)Mathf.Sign(vertical));
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        if(horizontalDown(horizontal)) {
            lastActionWasUndo = false;
            Debug.Log("lastActionWasUndo set to: " + lastActionWasUndo);

            if(movement.move((int)Mathf.Sign(horizontal), 0))
            {
                NextTurn();
                rotation.rotateOnMove((int)Mathf.Sign(horizontal), 0);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }

        if(Input.GetButtonDown("RotateL") && canRotate) {
            lastActionWasUndo = false;
            Debug.Log("lastActionWasUndo set to: " + lastActionWasUndo);

            rotation.RotateCounterClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }
        if(Input.GetButtonDown("RotateR") && canRotate) {
            lastActionWasUndo = false;
            Debug.Log("lastActionWasUndo set to: " + lastActionWasUndo);

            rotation.RotateClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }

        if(Input.GetButtonDown("Undo"))
        {
            GameObject.Find("MainUI").GetComponent<UIController>().SubtractTurn();

            Debug.Log("---UNDO INITIATED---");

            lastActionWasUndo = true;
            Debug.Log("lastActionWasUndo set to: " + lastActionWasUndo);
            undoEvents.undoLastMoveEvent.Invoke();
            movement.undoLastMove();
            rotation.undoLastMove();
            Debug.Log("Undo finished");
        }
        if(Input.GetButtonDown("Restart")) {
            undoEvents.restart();
        }

        oldHorizontal = horizontal;
        oldVertical = vertical;
    }

    private void NextTurn() {
        rotation.getActiveFace();
        GameObject.Find("MainUI").GetComponent<UIController>().AddTurn();
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