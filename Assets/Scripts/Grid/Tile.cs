using System.Collections.Generic;
using System.Collections;
using UnityEngine;

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
