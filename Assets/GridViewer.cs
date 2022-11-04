using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GridViewer : MonoBehaviour
{
    [SerializeField] private Vector2Int initialGridPos = Vector2Int.zero;
    private Vector2Int gridPos;
    public Vector2Int GetGridPosition() => gridPos;
    
    private void Awake()
    {
        gridPos = initialGridPos;
    }
    public void AddUnitX() 
    {
        if (gridPos.x+1 <= GridManager.GetGridLimits().x)
            gridPos.x++;
    }
    public void RemoveUnitX() 
    {
        if (gridPos.x-1 >= 0)
            gridPos.x--;
    }
    public void AddUnitY() 
    {
        if (gridPos.y+1 <= GridManager.GetGridLimits().y)
            gridPos.y++;
    }
    public void RemoveUnitY() 
    {
        if (gridPos.y-1 >= 0)
            gridPos.y--;
    }

}
