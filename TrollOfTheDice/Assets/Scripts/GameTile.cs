using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTile : GridAligned {
    protected Tilemap tilemap;
    
    private UndoEvents undoEvents;

    private void OnValidate() {
        if(levelGrid == null) {
            if(GetComponentInParent<TileParent>() == null) {
                Debug.Log("This object must be a child of a TileParent!");
            } else {
                levelGrid = GetComponentInParent<TileParent>().LevelGrid;
                tilemap = GetComponentInParent<TileParent>().Tilemap;
            }
        }

        snapToGrid();
    }

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
