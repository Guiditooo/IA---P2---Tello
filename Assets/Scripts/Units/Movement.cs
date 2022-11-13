using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public enum Movement_Direction
    {
        None, Up, Right, Down, Left
    };

    [SerializeField] private Movement_Direction nextDirection = default;
    
    private float timeElapsed;
    private Action Move;
    private GridViewer gridViewer = new GridViewer();

    void Update()
    {
        timeElapsed += Time.deltaTime;
        MoveSelector(nextDirection);
        if (timeElapsed > 1)
        {
            timeElapsed -= 1;
            Move?.Invoke();
            Debug.Log("ActualPos: " + gridViewer.GetGridPosition().x + "-" + gridViewer.GetGridPosition().y + ".");
        }
    }
    private void MoveSelector(Movement_Direction direction = Movement_Direction.None)
    {
        switch (direction)
        {
            case Movement_Direction.Up:
                Move = MoveUp;
                break;
            case Movement_Direction.Right:
                Move = MoveRight;
                break;
            case Movement_Direction.Down:
                Move = MoveDown;
                break;
            case Movement_Direction.Left:
                Move = MoveLeft;
                break;
            default:
                Move = DontMove;
                break;
        }
    }

    private void MoveUp()
    {
        gridViewer.AddUnitY();
    }
    private void MoveRight()
    {
        gridViewer.AddUnitX();
    }
    private void MoveDown()
    {
        gridViewer.RemoveUnitY();
    }
    private void MoveLeft()
    {
        gridViewer.RemoveUnitX();
    }
    private void DontMove()
    {

    }
}
