using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileParent : MonoBehaviour {
    [SerializeField] private Grid levelGrid;
    public Grid LevelGrid { get { return levelGrid; } }
    [SerializeField] private Tilemap tilemap;
    public Tilemap Tilemap { get { return tilemap; } }
    [SerializeField] private UndoEvents undoEvents;
    public UndoEvents UndoEvents { get { return undoEvents; } }
}
