using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * Crea las "Carpetas" en las que estaran almacenadas las unidades.
 * Crea al equipo verde en la parte inferior del mapa (yBottomPos).
 * Crea al equipo rojo en la parte superior del mapa (yTopPos).
 * Settea en el centro del mapa dependiendo de la cantidad de unidades por equipo que haya.
***/

public class UnitCreator
{ 

    private Transform unitsFolder = default;
    private Transform greenUnitsFolder = default;
    private Transform redUnitsFolder = default;

    private float unitSize = default;

    public UnitCreator(GameObject greenUnitPrefab, GameObject redUnitPrefab)
    {
        CreateFolders();
        CreateUnits(greenUnitPrefab, redUnitPrefab);
    }

    private void CreateUnits(GameObject greenUnitPrefab, GameObject redUnitPrefab)
    {

        unitSize = greenUnitPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileSize = GridBuilder.GetTileSize();

        GameObject unit = null;

        int xTopPos = GridManager.GetGridSize().x / 2 + GridManager.UnitsPerTeam / 2;
        int xBottomPos = GridManager.GetGridSize().x / 2 - GridManager.UnitsPerTeam / 2;

        int yTopPos = GridManager.GetGridLimits().y;
        int yBottomPos = 0;

        float padding = tileSize / 2 - unitSize / 2;

        for (int i = 0; i < GridManager.UnitsPerTeam; i++)
        {
            unit = GameObject.Instantiate(redUnitPrefab, redUnitsFolder);
            unit.name = "Red " + (i + 1).ToString();
            unit.GetComponent<Unit>().SetPosition(xTopPos - i, yTopPos);
            unit.transform.position = new Vector3(tileSize * (xTopPos - i), tileSize * yTopPos, 0);
        }
        for (int i = 0; i < GridManager.UnitsPerTeam; i++)
        {
            unit = GameObject.Instantiate(greenUnitPrefab, greenUnitsFolder);
            unit.name = "Green " + (i + 1).ToString();
            unit.GetComponent<Unit>().SetPosition(xBottomPos + i, yBottomPos);
            unit.transform.position = new Vector3(tileSize * (xBottomPos + i), tileSize * yBottomPos, 0);
        }

        UnitPositionHelper unitPH;

        unitPH.padding = padding;
        unitPH.tileSize = tileSize;

        GridManager.SetUnitPositionHelper(unitPH);
    }
    private void CreateFolders()
    {
        GameObject go = new GameObject();
        go.name = "Units";
        unitsFolder = go.transform;
        
        go = new GameObject();
        go.name = "Red Team";
        go.transform.SetParent(unitsFolder.transform);
        redUnitsFolder = go.transform;

        go = new GameObject();
        go.name = "Green Team";
        go.transform.SetParent(unitsFolder.transform);
        greenUnitsFolder = go.transform;
    }

}
