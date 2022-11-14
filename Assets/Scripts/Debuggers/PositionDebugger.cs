using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDebugger : MonoBehaviour
{
    private Unit unit = null;
    private bool hasUnit = false;

    private void Awake()
    {
        hasUnit = (unit = GetComponent<Unit>());
        if (!hasUnit)
        {
            Debug.Log("This Object does not have a Unit Script");
        }
    }

    private void Update()
    {
        if(hasUnit)
            Debug.Log("ActualPos: " + unit.GetPosition().x + "-" + unit.GetPosition().y + ".");
    }

}
