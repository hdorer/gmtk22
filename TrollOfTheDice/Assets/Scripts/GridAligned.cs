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

    protected void snapToGrid() {
        transform.position = levelGrid.CellToLocal(new Vector3Int(gridPosition.x, 0, gridPosition.y));
    }
}
