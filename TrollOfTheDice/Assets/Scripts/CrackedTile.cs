using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedTile : GridAligned
{
    private bool isBroken;
    public bool IsBroken { get { return isBroken; } }

    private Stack<bool> moveStates;

    private void Start() {
        moveStates = new Stack<bool>();
    }

    public void OnTriggerExit(Collider collision)
    {
        isBroken = true;
        gameObject.layer = LayerMask.NameToLayer("Wall");
    }

    public void addMoveState() {
        moveStates.Push(isBroken);
    }

    public void undoLastMove() {
        bool lastState = moveStates.Pop();

        isBroken = lastState;
    }
}
