using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerMovement movement;
    PlayerDieRotation rotation;
    
    private bool canRotate;
    public bool CanRotate { set { canRotate = value; } }

    private bool isUndoing;
    public bool IsUndoing { get { return isUndoing; } }

    [SerializeField] private UndoEvents undoEvents;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerDieRotation>();
    }

    private void Update() {
        // temporary movement code
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            isUndoing = false;

            if (movement.move(0, 1)) {
                rotation.rotateOnMove(0, 1);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            isUndoing = false;

            if (movement.move(0, -1)) {
                rotation.rotateOnMove(0, -1);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            isUndoing = false;

            if (movement.move(-1, 0)) {
                rotation.rotateOnMove(-1, 0);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            isUndoing = false;

            if (movement.move(1, 0)) {
                rotation.rotateOnMove(1, 0);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && canRotate) {
            isUndoing = false;

            rotation.RotateCounterClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E) && canRotate) {
            isUndoing = false;

            rotation.RotateClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Backspace)) {
            isUndoing = true;
            undoEvents.undoLastMoveEvent.Invoke();
        }
    }

    private void NextTurn()
    {
        rotation.getActiveFace();

    }
}
