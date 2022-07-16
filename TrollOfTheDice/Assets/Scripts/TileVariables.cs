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
    [SerializeField] private Tile activeTile;
    [SerializeField] private Tile inactiveTile;
    public Vector2Int GridPosition { get { return gridPosition; } }
    public bool IsActive { get { return isActive; } }

    public void OnTriggerEnter(Collider collision)
    {
        int dieFace = collision.gameObject.GetComponent<PlayerDieRotation>().getActiveFace();
        //Vector3Int currentCell = tilemap.WorldToCell(transform.position);

        if (dieFace == victoryNum)
        {
            tilemap.SetTile(currentCell, activeTile);
            isActive = true;
            //levelGrid.GetComponent<VictoryCheck>().CheckIfWin();
        }
        else if (!isPermanent)
        {
            tilemap.SetTile(currentCell, inactiveTile);
            //isActive = false;
        }
    }
}
