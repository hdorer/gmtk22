using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GridAligned {
    public void move(int x, int y) {
        gridPosition.x += x;
        gridPosition.y += y;

        snapToGrid();
    }
}
