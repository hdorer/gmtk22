using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GridAligned {
    [SerializeField] LayerMask wallLayer;
    
    public bool move(int x, int y) {
        if(Physics.Raycast(transform.position, new Vector3(x, 0, 0), 2f, wallLayer)) {
            return false;
        }
        if(Physics.Raycast(transform.position, new Vector3(0, 0, y), 2f, wallLayer)) {
            return false;
        }

        gameObject.GetComponent<PlayerInput>().DisableRotate();

        gridPosition.x += x;
        gridPosition.y += y;
        snapToGrid();
        return true;
    }
}
