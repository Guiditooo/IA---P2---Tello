using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Vector2Int gridPos;
    private GridViewer gridViewer;
    public Vector2Int GridPos
    {
        get
        {
            return gridPos;
        }
        set
        {
            gridPos = value;
            if (gridViewer != null)
                gridViewer = new GridViewer(value);
        }
    }
    public Food(Vector2Int newGridPos)
    {
        gridPos = newGridPos;
    }

    private void Start()
    {
        if(gridViewer!=null)
            gridViewer = new GridViewer(gridPos);
    }
    
}
