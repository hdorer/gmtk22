using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : GridAligned
{
    public void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<PlayerInput>().EnableRotate();
    }
}
