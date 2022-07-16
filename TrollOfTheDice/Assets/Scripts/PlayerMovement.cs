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
    private AudioSource[] audio;

    private void Start() {
        antimoves = new Stack<Antimove>();
        audio = gameObject.GetComponents<AudioSource>();
    }

    public bool move(int x, int y, bool undoing = false) {
        if(!undoing) {
            if(Physics.Raycast(transform.position, new Vector3(x, 0, 0), 2f, wallLayer)) {
                return false;
            }
            if(Physics.Raycast(transform.position, new Vector3(0, 0, y), 2f, wallLayer)) {
                return false;
            }
        }

        audio[0].Play();

        gridPosition.x += x;
        gridPosition.y += y;
        snapToGrid();

        if(!undoing) {
            antimoves.Push(new Antimove(-x, -y));
        }

        return true;
    }

    public void addNeutralAntimove() {
        antimoves.Push(new Antimove(0, 0));
    }
    
    public void undoLastMove()
    {
        audio[0].Play();

        Antimove lastMove = antimoves.Pop();

        move(lastMove.x, lastMove.y, true);
    }
}
