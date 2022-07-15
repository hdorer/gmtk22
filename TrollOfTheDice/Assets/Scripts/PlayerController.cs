using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Grid levelGrid;
    private Vector3Int gridPosition;

    private void Start() {
        gridPosition = levelGrid.WorldToCell(transform.position);
        Debug.Log("Converted grid position: " + gridPosition);

        transform.position = levelGrid.CellToWorld(gridPosition);
        Debug.Log("New world position: " + transform.position);
    }
}
