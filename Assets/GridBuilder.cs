using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab = null;
    [SerializeField] private Transform tileMap = default;

    private void Start()
    {
        float imgSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        for (int y = 0; y < GridManager.GetGridLimits().y; y++) //Cada Fila
        {
            for (int x = 0; x < GridManager.GetGridLimits().x; x++) //Cada Columna
            {
                GameObject newTile = Instantiate(tilePrefab, tileMap);
                newTile.GetComponent<Tile>().SetPosition(x, y);
                newTile.transform.position = new Vector3(imgSize * x, imgSize * y, 0);
                newTile.name = x.ToString() + "-" + y.ToString();
            }
        }

    }


}
