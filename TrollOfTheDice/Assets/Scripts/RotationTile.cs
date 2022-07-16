using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : GridAligned
{
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerInput>().CanRotate = true;
    }

    public void OnTriggerExit(Collider other) {
        other.gameObject.GetComponent<PlayerInput>().CanRotate = false;
    }
}
