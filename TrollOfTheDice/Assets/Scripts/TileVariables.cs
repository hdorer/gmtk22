using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileVariables : GameTile {
    [SerializeField] private int victoryNum;
    [SerializeField] private bool isActive;
    public bool IsActive { get { return isActive; } }
    [SerializeField] private bool isPermanent;
    [SerializeField] private Sprite[] activeSprites;
    [SerializeField] private Sprite[] inactiveSprites;
    public Vector2Int GridPosition { get { return gridPosition; } }

    private Stack<bool> moveStates;

    private void Start() {
        moveStates = new Stack<bool>();

        updateTileColor();
    }

    public void OnTriggerEnter(Collider collision) {
        int dieFace = collision.gameObject.GetComponent<PlayerDieRotation>().getActiveFace();

        if(dieFace == victoryNum) {
            isActive = true;
            levelGrid.GetComponent<VictoryCheck>().CheckIfWin();
            PitchRandomizer.PlaySoundPitchRandomized(gameObject.GetComponent<AudioSource>(), 1.2f, 1.6f);
        } else if(!isPermanent) {
            isActive = false;
        }

        updateTileColor();
    }

    private void updateTileColor() {
        Vector3Int currentCell = new Vector3Int(GridPosition.x, GridPosition.y - 1, 0);
        UnityEngine.Tilemaps.Tile tile = ScriptableObject.CreateInstance<UnityEngine.Tilemaps.Tile>();

        if(isActive) {
            tile.sprite = activeSprites[victoryNum - 1];
        } else {
            tile.sprite = inactiveSprites[victoryNum - 1];
        }

        tilemap.SetTile(currentCell, tile);
    }

    protected override void addMoveState() {
        moveStates.Push(isActive);
    }

    protected override void undoLastMove() {
        bool lastState = moveStates.Pop();

        isActive = lastState;
        updateTileColor();
    }
}
