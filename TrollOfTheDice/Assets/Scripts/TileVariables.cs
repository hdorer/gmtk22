using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileVariables : GridAligned
{
    [SerializeField] private int victoryNum;
    [SerializeField] private bool isActive;
    [SerializeField] private bool isPermanent;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Sprite[] activeSprites;
    [SerializeField] private Sprite[] inactiveSprites;
    public Vector2Int GridPosition { get { return gridPosition; } }
    public bool IsActive { get { return isActive; } }

    public void OnTriggerEnter(Collider collision)
    {
        int dieFace = collision.gameObject.GetComponent<PlayerDieRotation>().getActiveFace();
        Vector3Int currentCell = new Vector3Int(GridPosition.x, GridPosition.y - 1, 0);

        Tile tile = ScriptableObject.CreateInstance<Tile>();

        if (dieFace == victoryNum)
        {
            tile.sprite = activeSprites[victoryNum - 1];
            tilemap.SetTile(currentCell, tile);
            isActive = true;
            levelGrid.GetComponent<VictoryCheck>().CheckIfWin();
        }
        else if (!isPermanent)
        {
            tile.sprite = inactiveSprites[victoryNum - 1];
            tilemap.SetTile(currentCell, tile);
            isActive = false;
        }
    }
}
