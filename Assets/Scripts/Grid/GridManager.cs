using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/***
 * Esto contiene la información de la grilla.
 * GetGridLimits devuelve el valor máximo alcanzable en la grilla.
 * GetGridSize devuelve el tamaño de la grilla.
***/
public class GridManager : MonoBehaviour
{
    [Header("Grid Related")]
    [SerializeField] private int initialGridWidth = 20;
    [SerializeField] private int initialGridHeight = 20;

    [Header("Units Related")]
    [SerializeField] private int initialUnitsPerTeam = 10;

    [Header("Builder Related")]
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject greenUnitPrefab;
    [SerializeField] private GameObject redUnitPrefab;
    [SerializeField] private GameObject foodPrefab;

    private static int gridWidth = default;
    private static int gridHeight = default;
    private static int unitsPerTeam = default;
    private static int foodOnMap = default;

    private static UnitPositionHelper unitPH = default;
    public static void SetUnitPositionHelper(UnitPositionHelper newUnitPH)
    {
        unitPH = newUnitPH;
    }
    public static UnitPositionHelper GetUnitPositionHelper() => unitPH;

    public static int GetFoodCount() => foodOnMap;
    public static Vector2Int GetGridLimits()///Returns max reachable value on grid
    {
        return new Vector2Int(gridWidth - 1, gridHeight - 1);
    }
    public static Vector2Int GetGridSize()///Returns the size of the grid
    {
        return new Vector2Int(gridWidth, gridHeight);
    }

    public static int UnitsPerTeam 
    { 
        get 
        { 
            return unitsPerTeam; 
        } 
    }

    private void Awake()
    {
        gridWidth = initialGridWidth;
        gridHeight = initialGridHeight;
        if (initialUnitsPerTeam <= initialGridWidth)
        {
            unitsPerTeam = initialUnitsPerTeam;
        }
        else
        {
            unitsPerTeam = initialGridWidth;
        }
        foodOnMap = unitsPerTeam * 2;
    }

    private void Start()
    {
        MapBuilder.BuildMap(tilePrefab, greenUnitPrefab, redUnitPrefab, foodPrefab);
    }

}
