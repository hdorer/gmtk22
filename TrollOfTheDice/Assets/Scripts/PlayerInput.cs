using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerMovement movement;
    PlayerDieRotation rotation;
    private bool canRotate;
    public bool CanRotate { set { canRotate = value; } }

    float oldHorizontal, oldVertical;

    private bool isUndoing;
    public bool IsUndoing { get { return isUndoing; } }

    [SerializeField] private UndoEvents undoEvents;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerDieRotation>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // temporary movement code
        if(verticalDown(vertical)) {
            isUndoing = false;

            if (movement.move(0, (int)Mathf.Sign(vertical))) {
                rotation.rotateOnMove(0, (int)Mathf.Sign(vertical));
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        if(horizontalDown(horizontal)) {
            isUndoing = false;

            if (movement.move((int)Mathf.Sign(horizontal), 0)) {
                rotation.rotateOnMove((int)Mathf.Sign(horizontal), 0);
                undoEvents.addMoveStateEvent.Invoke();
            }
        }
        
        if (Input.GetButtonDown("RotateL") && canRotate) {
            isUndoing = false;

            rotation.RotateCounterClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }
        if (Input.GetButtonDown("RotateR") && canRotate) {
            isUndoing = false;

            rotation.RotateClockwise();
            movement.addNeutralAntimove();
            undoEvents.addMoveStateEvent.Invoke();
        }

        if(Input.GetButtonDown("Undo")) {
            isUndoing = true;
            undoEvents.undoLastMoveEvent.Invoke();
        }

        oldHorizontal = horizontal;
        oldVertical = vertical;
    }

    private void NextTurn()
    {
        rotation.getActiveFace();

    }

    private bool horizontalDown(float horizontal) {
        if(horizontal != 0 && horizontal != oldHorizontal) {
            return true;
        }
        return false;
    }

    private bool verticalDown(float vertical) {
        if(vertical != 0 && vertical != oldVertical) {
            return true;
        }
        return false;
    }
}
