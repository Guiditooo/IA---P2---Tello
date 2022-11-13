using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int initialGridWidth = 20;
    [SerializeField] private int initialGridHeight = 20;

    private static int gridWidth = default;
    private static int gridHeight = default;

    public static Vector2Int GetGridLimits()
    {
        return new Vector2Int(gridWidth - 1, gridHeight - 1);
    }
    public static Vector2Int GetGridSize()
    {
        return new Vector2Int(gridWidth, gridHeight);
    }
    private void Awake()
    {
        gridWidth = initialGridWidth;
        gridHeight = initialGridHeight;
    }

}
