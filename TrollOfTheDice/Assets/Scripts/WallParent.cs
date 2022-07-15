using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallParent : MonoBehaviour {
    [SerializeField] private Grid levelGrid;
    public Grid LevelGrid { get { return levelGrid; } }
}
