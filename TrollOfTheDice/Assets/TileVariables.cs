using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVariables : GridAligned
{
    [SerializeField] private int victoryNum;
    [SerializeField] private bool isActive;
    [SerializeField] private bool isPermanent;
    public Vector2Int GridPosition { get { return gridPosition; } }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int dieFace = collision.gameObject.GetComponent<PlayerDieRotation>().getActiveFace();

        if (dieFace == victoryNum) { isActive = true; }
        else if (!isPermanent) { isActive = false; }
    }
}
