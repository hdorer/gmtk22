using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridAligned : MonoBehaviour {
    [SerializeField] protected Grid levelGrid;
    [SerializeField] protected Vector2Int gridPosition;

    private void OnValidate() {
        snapToGrid();
    }

    private void Start() {
        snapToGrid();
    }

    [ContextMenu("Snap to Grid")]
    protected void snapToGrid() {
        transform.position = levelGrid.CellToLocal(new Vector3Int(gridPosition.x, gridPosition.y, 0));
    }
}
