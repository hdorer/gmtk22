using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GridAligned {
    private struct Antimove {
        public int x, y;

        public Antimove(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    [SerializeField] private LayerMask wallLayer;
    
    private Stack<Antimove> antimoves;
    
    private AudioSource[] audioSources;

    [SerializeField] private CameraSwitcher cameras;

    private void Start() {
        antimoves = new Stack<Antimove>();
        audioSources = gameObject.GetComponents<AudioSource>();
    }

    public bool move(int x, int y, bool undoing = false) {
        int xMove = x;
        int yMove = y;

        if(cameras.reverseAngle && !undoing) {
            xMove *= -1;
            yMove *= -1;
        }

        if(!undoing) {
            if(Physics.Raycast(transform.position, new Vector3(xMove, 0, 0), 2f, wallLayer)) {
                return false;
            }
            if(Physics.Raycast(transform.position, new Vector3(0, 0, yMove), 2f, wallLayer)) {
                return false;
            }
        }

        PitchRandomizer.PlaySoundPitchRandomized(audioSources[0], 0.8f, 1.2f);

        gridPosition.x += xMove;
        gridPosition.y += yMove;
        snapToGrid();

        if(!undoing) {
            antimoves.Push(new Antimove(-xMove, -yMove));
        }

        return true;
    }

    public void addNeutralAntimove() {
        antimoves.Push(new Antimove(0, 0));
    }
    
    public void undoLastMove()
    {
        //Allows for smoother audio playing
        PitchRandomizer.PlaySoundPitchRandomized(audioSources[0], 1.2f, 1.6f);
        //audio[0].Play();

        Antimove lastMove = antimoves.Pop();

        move(lastMove.x, lastMove.y, true);
        Debug.Log("Player's last move undone");
    }
}
