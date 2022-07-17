using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTile : GridAligned {
    [SerializeField] protected Tilemap tilemap;

    [SerializeField] private UndoEvents undoEvents;

    private void OnValidate() {
        if(GetComponentInParent<TileParent>() == null) {
            Debug.Log("This object must be a child of a TileParent!");
        } else {
            if(levelGrid == null) {
                levelGrid = GetComponentInParent<TileParent>().LevelGrid;
            }
            if(tilemap == null) {
                tilemap = GetComponentInParent<TileParent>().Tilemap;
            }
            if(undoEvents == null) {
                undoEvents = GetComponentInParent<TileParent>().UndoEvents;
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
