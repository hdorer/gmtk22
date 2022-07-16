using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedTile : GridAligned
{
    private bool isBroken;
    public bool IsBroken { get { return isBroken; } }

    public void OnTriggerExit(Collider collision)
    {
        isBroken = true;
        gameObject.layer = LayerMask.NameToLayer("Wall");
    }
}
