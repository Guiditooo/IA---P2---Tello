using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/***
 * Instancio cada Tile dependiendo de la cantidad de ancho y alto que se haya especificado en el GridManager.
 * El prefab de Tile ya viene con su respectivo Sprite Renderer, por eso no se debe romper.
 * Se usa GetGridSize porque devuelte el valor exacto especificado en el GridManager.
 * Se usa el objeto "Tile Map" para englobar las tiles.
 * Es el encargado de darle a cada tile la posicion que le corresponde en el espacio de unity.
***/
public class GridBuilder : MonoBehaviour
{
    [Header("Tile Prefab")]
    [SerializeField] private GameObject tilePrefab = null;
    [Header("Target Folder")]
    [SerializeField] private Transform tileMap = default;


    private static float tileSize = default;
    public static float GetTileSize() => tileSize;

    private void Start()
    {
        tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        for (int y = 0; y < GridManager.GetGridSize().y; y++) //Cada Fila
        {
            for (int x = 0; x < GridManager.GetGridSize().x; x++) //Cada Columna
            {
                GameObject newTile = Instantiate(tilePrefab, tileMap);
                newTile.GetComponent<Tile>().SetPosition(x, y);
                newTile.transform.position = new Vector3(tileSize * x, tileSize * y, 0);
                newTile.name = x.ToString() + "-" + y.ToString();
            }
        }

    }


}
