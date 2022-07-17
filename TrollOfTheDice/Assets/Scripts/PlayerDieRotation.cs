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
    
    private AudioSource[] audioClips;

    [SerializeField] CameraSwitcher cameras;

    private void Start() {
        antirotates = new Stack<Antirotate>();
        audioClips = gameObject.GetComponents<AudioSource>();
    }

    public void rotateOnMove(int x, int z) {
        int xRot = x;
        int zRot = z;

        if(cameras.reverseAngle) {
            xRot *= -1;
            zRot *= -1;
        }

        transform.Rotate(90 * zRot, 0, -90 * xRot, Space.World);

        antirotates.Push(new Antirotate(-90 * zRot, 0, 90 * xRot));
    }

    public int getActiveFace() {
        for (int i = 0; i < sides.Length; i++)
        {
            float pos = sides[i].position.y;
            if (pos - gameObject.transform.position.y > 0.01) {
                return i + 1;
            }
        }

        Debug.Log("THERE WAS A BAD ERROR");
        return 0;
    }

    public void RotateClockwise() {
        PitchRandomizer.PlaySoundPitchRandomized(audioClips[1], 1.0f, 1.2f);

        if(cameras.reverseAngle) {
            transform.Rotate(0, -90, 0, Space.World);
            antirotates.Push(new Antirotate(0, 90, 0));
        } else {
            transform.Rotate(0, 90, 0, Space.World);
            antirotates.Push(new Antirotate(0, -90, 0));
        }

    }

    public void RotateCounterClockwise()
    {
        PitchRandomizer.PlaySoundPitchRandomized(audioClips[1], 0.8f, 1.0f);

        if(cameras.reverseAngle) {
            transform.Rotate(0, 90, 0, Space.World);
            antirotates.Push(new Antirotate(0, -90, 0));
        } else {
            transform.Rotate(0, -90, 0, Space.World);
            antirotates.Push(new Antirotate(0, 90, 0));
        }
    }

    public void undoLastMove() {
        Antirotate lastRotation = antirotates.Pop();
        transform.Rotate(lastRotation.x, lastRotation.y, lastRotation.z, Space.World);
    }
}
