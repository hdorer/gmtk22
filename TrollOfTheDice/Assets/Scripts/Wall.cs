using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : GridAligned {
    private void OnValidate() {
        if(levelGrid == null) {
            if(GetComponentInParent<WallParent>() == null) {
                Debug.Log("This object must be a child of a WallParent!");
            } else {
                levelGrid = GetComponentInParent<WallParent>().LevelGrid;
            }
        }

        snapToGrid();
    }
}
