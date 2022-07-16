using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undoable : GridAligned {
    private UndoEvents undoEvents;

    private void Awake() {
        undoEvents = levelGrid.GetComponent<UndoEvents>();

        undoEvents.addMoveStateEvent.AddListener(addMoveState);
        undoEvents.undoLastMoveEvent.AddListener(undoLastMove);
    }

    private void OnDestroy() {
        undoEvents.addMoveStateEvent.RemoveListener(addMoveState);
        undoEvents.undoLastMoveEvent.RemoveListener(undoLastMove);
    }

    protected virtual void addMoveState() { }
    protected virtual void undoLastMove() { }
}
