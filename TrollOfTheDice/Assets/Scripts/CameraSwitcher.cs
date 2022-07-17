using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    private void Update() {
        if(Input.GetButtonDown("NextCam")) {
            Debug.Log("Right mouse button");
        }
        if(Input.GetButtonDown("PrevCam")) {
            Debug.Log("Left mouse button");
        }
    }
}
