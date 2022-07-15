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

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // temporary movement code
        if(Input.GetKeyDown(KeyCode.W)) {
            move(0, 1);
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            move(0, -1);
        }
        if(Input.GetKeyDown(KeyCode.A)) {
            move(-1, 0);
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            move(1, 0);
        }
    }

    private void move(int x, int z) {
        gridPosition.x += x;
        gridPosition.z += z;

        transform.position = levelGrid.CellToWorld(gridPosition);
    }
}
