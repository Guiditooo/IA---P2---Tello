using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/***
 * Esto contiene la información de un Tile.
 * SetPosition le da la posicion al Tile en el momento en el que se instancia.
***/

public class Tile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePos = Vector2Int.zero;
    public Vector2Int GetTilePos() => tilePos;
    public void SetPosition(Vector2Int newPos)
    {
        tilePos = newPos;
    }
    public void SetPosition(int newX, int newY)
    {
        tilePos = new Vector2Int(newX, newY);
    }

}
