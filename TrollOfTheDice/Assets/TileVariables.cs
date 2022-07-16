using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVariables : GridAligned
{
    [SerializeField] private int victoryNum;
    [SerializeField] private bool isActive;
    [SerializeField] private bool isPermanent;
    public Vector2Int GridPosition { get { return gridPosition; } }
    public bool IsActive { get { return isActive; } }

    public void OnTriggerEnter(Collider collision)
    {
        int dieFace = collision.gameObject.GetComponent<PlayerDieRotation>().getActiveFace();

        Debug.Log(dieFace);

        if (dieFace == victoryNum) { isActive = true; }
        else if (!isPermanent) { isActive = false; }
    }
}
