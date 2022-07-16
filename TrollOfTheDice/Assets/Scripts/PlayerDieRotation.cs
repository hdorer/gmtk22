using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieRotation : MonoBehaviour {
    [SerializeField] private Transform[] sides;

    public void rotateOnMove(int x, int z) {
        transform.Rotate(90 * z, 0, 0, Space.World);
        transform.Rotate(0, 0, -90 * x, Space.World);
    }

    public int getActiveFace() {
        for (int i = 0; i < sides.Length; i++)
        {
            float pos = sides[i].position.y;
            if (pos - gameObject.transform.position.y > 0.01) {
                return (int)(i + 1);
            }
        }

        Debug.Log("THERE WAS A BAD ERROR");
        return 0;
    }

    public void RotateClockwise() { transform.Rotate(0, 90, 0, Space.World); }
    public void RotateCounterClockwise() { transform.Rotate(0, -90, 0, Space.World); }
}
