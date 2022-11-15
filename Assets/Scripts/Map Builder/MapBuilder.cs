using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder
{
    public static void BuildMap(GameObject tilePrefab, GameObject greenUnitPrefab, GameObject redUnitPrefab, GameObject foodPrefab)
    {
        new GridBuilder(tilePrefab);

        new UnitCreator(greenUnitPrefab, redUnitPrefab);

        new FoodPlacer(foodPrefab);
    }


}
