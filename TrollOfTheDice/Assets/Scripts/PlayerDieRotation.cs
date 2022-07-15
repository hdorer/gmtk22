using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieRotation : MonoBehaviour {
    public void rotateOnMove(int x, int z) {
        transform.Rotate(90 * z, 0, 0, Space.World);
        transform.Rotate(0, 0, -90 * x, Space.World);
    }
}
