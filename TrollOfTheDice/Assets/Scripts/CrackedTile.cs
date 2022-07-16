using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedTile : GridAligned
{
    private bool isBroken;
    public bool IsBroken { get { return isBroken; } }

    public void OnTriggerExit(Collider collision) {
        if(collision.gameObject.GetComponent<PlayerInput>().IsUndoing) {
            return;
        }

        isBroken = true;
        gameObject.layer = LayerMask.NameToLayer("Wall");
    }

    public void OnTriggerEnter(Collider collision)
    {
        isBroken = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    /*
    private Stack<bool> moveStates;
    private bool ignoreTriggerExit;

    private void Start() {
        moveStates = new Stack<bool>();
    }

    private void Update() {
        ignoreTriggerExit = false;
    }
    

    public void addMoveState() {
        moveStates.Push(isBroken);
    }

    public void undoLastMove() {
        ignoreTriggerExit = true;
        bool lastState = moveStates.Pop();
        isBroken = lastState;
    }*/
}
