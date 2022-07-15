using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GridAligned {
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

    private void move(int x, int y) {
        gridPosition.x += x;
        gridPosition.y += y;

        snapToGrid();
    }
}
