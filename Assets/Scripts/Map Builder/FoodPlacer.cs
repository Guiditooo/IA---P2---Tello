using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacer
{
    // Start is called before the first frame update

    private static List<Food> foodList = new List<Food>();

    float foodSize = default;

    float padding = default;

    public FoodPlacer(GameObject foodPrefab)
    {

        GameObject folder = new GameObject("Food");

        foodSize = foodPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        padding = GridManager.GetUnitPositionHelper().tileSize / 2 - foodSize / 2;

        GameObject food;

        for (int i = 0; i < GridManager.GetFoodCount(); i++)
        {
            food = GameObject.Instantiate(foodPrefab, folder.transform);
            food.name = "Food " + (i + 1).ToString();
            PlaceFoodInRandomPos(food);
        }

    }

    private void PlaceFoodInRandomPos(GameObject foodToConvert)
    {
        bool reset;
        Vector2Int possiblePos;
        do
        {
            reset = false;
            int possibleX = Random.Range(0, GridManager.GetGridSize().x);
            int possibleY = Random.Range(2, GridManager.GetGridLimits().y-1);
            
            
            possiblePos = new Vector2Int(possibleX, possibleY);
            foreach (Food food in foodList)
            {
                if(food.GridPos.Equals(possiblePos))
                {
                    reset = true;
                    return;
                }
            }
        } while (reset);

        UnitPositionHelper UPH = GridManager.GetUnitPositionHelper();
        Food auxFood = foodToConvert.AddComponent<Food>();
        auxFood.GridPos = possiblePos;
        foodToConvert.transform.position = new Vector3(UPH.tileSize * possiblePos.x, UPH.tileSize * possiblePos.y, 0);

        foodList.Add(auxFood);

    }


}
