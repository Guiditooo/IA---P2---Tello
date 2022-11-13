using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * Crea las "Carpetas" en las que estaran almacenadas las unidades.
 * Crea al equipo verde en la parte inferior del mapa (yBottomPos).
 * Crea al equipo rojo en la parte superior del mapa (yTopPos).
 * Settea en el centro del mapa dependiendo de la cantidad de unidades por equipo que haya.
***/

public class UnitCreator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject greenUnitPrefab = null;
    [SerializeField] private GameObject redUnitPrefab = null;

    private Transform unitsFolder = default;
    private Transform greenUnitsFolder = default;
    private Transform redUnitsFolder = default;

    void Start()
    {
        CreateFolders();
        CreateUnits();
        Destroy(this.gameObject);
    }

    private void CreateUnits()
    {
        GameObject unit = null;

        int xInitialPos = GridManager.GetGridSize().x / 2 - GridManager.UnitsPerTeam / 2;

        int yTopPos = GridManager.GetGridLimits().y;
        int yBottomPos = 0;

        for (int i = 0; i < GridManager.UnitsPerTeam; i++)
        {
            unit = Instantiate(redUnitPrefab, redUnitsFolder);
            unit.name = "Red " + (i+1).ToString();
            unit.GetComponent<Unit>().SetPosition(xInitialPos + i, yTopPos);
        }
        for (int i = 0; i < GridManager.UnitsPerTeam; i++)
        {
            unit = Instantiate(greenUnitPrefab, greenUnitsFolder);
            unit.name = "Green " + (i + 1).ToString();
            unit.GetComponent<Unit>().SetPosition(xInitialPos + i, yBottomPos);
        }
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
