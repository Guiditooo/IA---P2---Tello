using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(GridViewer))]
public class Movement : MonoBehaviour
{
    
    public enum Movement_Direction
    {
        Up, Right, Down, Left, None
    };

    [SerializeField] private float speed;
    
    private float timeElapsed;

    private Action Move;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        MoveSelector();
        if(timeElapsed>1)
        {
            timeElapsed -= 1;

        }
    }
    private void MoveSelector(Movement_Direction direction = Movement_Direction.None)
    {
        switch (direction)
        {
            case Movement_Direction.Up:
                break;
            case Movement_Direction.Right:
                break;
            case Movement_Direction.Down:
                break;
            case Movement_Direction.Left:
                break;
            case Movement_Direction.None:
            default:
                break;
        }
    }
}
