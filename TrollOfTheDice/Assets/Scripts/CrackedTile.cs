using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedTile : Undoable {
    private bool isBroken;
    public bool IsBroken { get { return isBroken; } }

    private Stack<bool> moveStates;
    private bool ignoreTriggerExit;

    private void Start() {
        moveStates = new Stack<bool>();
    }

    private void Update() {
        ignoreTriggerExit = false;
    }

    public void OnTriggerExit(Collider collision) {
        if(ignoreTriggerExit) {
            return;
        }

        isBroken = true;
        gameObject.layer = LayerMask.NameToLayer("Wall");
    }

    protected override void addMoveState() {
        moveStates.Push(isBroken);
    }

    protected override void undoLastMove() {
        ignoreTriggerExit = true;
        bool lastState = moveStates.Pop();
        isBroken = lastState;
    }
}
