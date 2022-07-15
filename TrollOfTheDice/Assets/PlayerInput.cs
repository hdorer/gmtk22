using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    PlayerMovement movement;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // temporary movement code
        if(Input.GetKeyDown(KeyCode.W)) {
            movement.move(0, 1);
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            movement.move(0, -1);
        }
        if(Input.GetKeyDown(KeyCode.A)) {
            movement.move(-1, 0);
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            movement.move(1, 0);
        }
    }
}
