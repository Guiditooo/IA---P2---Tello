using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/***
 * Esto contiene la información necesaria para que una unidad reconozca la grilla
 * Permite el movimiento en la grilla agregando o sacando valores de X.
 * 
***/

public class GridViewer
{
    private Vector2Int gridPos = default;
    public Vector2Int GetGridPosition() => gridPos;

    public void SetGridPosition(Vector2Int newGridPos)
    {
        gridPos = newGridPos;
    }
    public void SetGridPosition(int x, int y)
    {
        gridPos = new Vector2Int(x,y);
    }

    public void AddUnitX() 
    {
        if (gridPos.x + 1 <= GridManager.GetGridLimits().x)
        {
            gridPos.x++;
        }
        else
        {
            gridPos.x = 0;
        }
    }
    public void RemoveUnitX()
    {
        if (gridPos.x - 1 >= 0)
        {
            gridPos.x--;
        }
        else
        {
            gridPos.x = GridManager.GetGridLimits().x;
        }
    }
    public void AddUnitY() 
    {
        if (gridPos.y + 1 <= GridManager.GetGridLimits().y)
        {
            gridPos.y++;
        }

    }
    public void RemoveUnitY() 
    {
        if (gridPos.y-1 >= 0)
            gridPos.y--;
    }

}
