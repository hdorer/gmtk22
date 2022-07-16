using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieRotation : MonoBehaviour {
    private struct Antirotate {
        public int x, y, z;
        
        public Antirotate(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [SerializeField] private Transform[] sides;
    private Stack<Antirotate> antirotates;
    private AudioSource[] audio;

    private void Start() {
        antirotates = new Stack<Antirotate>();
        audio = gameObject.GetComponents<AudioSource>();
    }

    public void rotateOnMove(int x, int z) {
        transform.Rotate(90 * z, 0, 90 * x, Space.World);

        antirotates.Push(new Antirotate(-90 * z, 0, -90 * x));
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

    public void RotateClockwise()
    {
        audio[1].Play();
        transform.Rotate(0, 90, 0, Space.World);
        antirotates.Push(new Antirotate(0, -90, 0));

    }

    public void RotateCounterClockwise()
    {
        audio[1].Play();
        transform.Rotate(0, -90, 0, Space.World);
        antirotates.Push(new Antirotate(0, 90, 0));
    }

    public void undoLastMove() {
        Antirotate lastRotation = antirotates.Pop();
        transform.Rotate(lastRotation.x, lastRotation.y, lastRotation.z, Space.World);
    }
}
