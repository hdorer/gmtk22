using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CrackedTile : GameTile {
    private bool isBroken;
    public bool IsBroken { get { return isBroken; } }

    private Stack<bool> moveStates;

    [SerializeField] private Sprite intactSprite;
    [SerializeField] private Sprite brokenSprite;

    private void Start() {
        moveStates = new Stack<bool>();

        updateTileSprite();
    }

    public void OnTriggerExit(Collider collision) {
        PlayerInput pInput = collision.gameObject.GetComponent<PlayerInput>();
        if(pInput.LastActionWasUndo) {
            Debug.Log("Ignoring trigger exit");
            return;
        }

        isBroken = true;
        gameObject.layer = LayerMask.NameToLayer("Wall");
        Debug.Log("Player exits trigger, isBroken is " + isBroken + ", layer set to Wall");

        PitchRandomizer.PlaySoundPitchRandomized(gameObject.GetComponent<AudioSource>(), 1.2f, 1.6f); 

        updateTileSprite();
    }

    protected override void addMoveState() {
        moveStates.Push(isBroken);
    }

    protected override void undoLastMove() {
        bool lastState = moveStates.Pop();
        Debug.Log("Last state was " + lastState);
        isBroken = lastState;
        Debug.Log("isBroken is now " + isBroken);

        if(!isBroken) {
            gameObject.layer = LayerMask.NameToLayer("Default");
            Debug.Log("Layer set to Default");
        }

        updateTileSprite();
    }

    private void updateTileSprite() {
        Vector3Int currentCell = new Vector3Int(gridPosition.x, gridPosition.y - 1, 0);
        UnityEngine.Tilemaps.Tile tile = ScriptableObject.CreateInstance<UnityEngine.Tilemaps.Tile>();

        if(isBroken) {
            tile.sprite = brokenSprite;
        } else {
            tile.sprite = intactSprite;
        }

        tilemap.SetTile(currentCell, tile);
    }
}
