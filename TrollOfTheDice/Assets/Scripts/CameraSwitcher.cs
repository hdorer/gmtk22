using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    [SerializeField] CinemachineVirtualCamera[] cameras;
    int currentCamera = 0;
    public bool reverseAngle { get { return currentCamera == 2 || currentCamera == 3; } }

    private void Start() {
        updateCameraPriorities();
    }

    private void Update() {
        if(Input.GetButtonDown("NextCam")) {
            currentCamera++;
            if(currentCamera >= cameras.Length) {
                currentCamera = 0;
            }
            Debug.Log("Current camera is " + currentCamera);

            updateCameraPriorities();
        }

        if(Input.GetButtonDown("PrevCam")) {
            currentCamera--;
            if(currentCamera < 0) {
                currentCamera = cameras.Length - 1;
            }
            Debug.Log("Current camera is " + currentCamera);

            updateCameraPriorities();
        }
    }

    private void updateCameraPriorities() {
        for(int i = 0; i < cameras.Length; i++) {
            if(i == currentCamera) {
                cameras[i].Priority = 1;
            } else {
                cameras[i].Priority = 0;
            }

            Debug.Log("Camera " + i + " has priority " + cameras[i].Priority);
        }
    }
}
