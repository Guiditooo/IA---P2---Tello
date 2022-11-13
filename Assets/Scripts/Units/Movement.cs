using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Movement
{
    public enum Movement_Direction
    {
        None, Up, Right, Down, Left
    };

    private Movement_Direction nextDirection = default;
    
    public void SetNextMovement(Movement_Direction direction = Movement_Direction.None)
    {
        switch (direction)
        {
            case Movement_Direction.Up:
                NextMove = MoveUp;
                break;
            case Movement_Direction.Right:
                NextMove = MoveRight;
                break;
            case Movement_Direction.Down:
                NextMove = MoveDown;
                break;
            case Movement_Direction.Left:
                NextMove = MoveLeft;
                break;
            default:
                NextMove = DontMove;
                break;
        }
        nextDirection = direction;
    }

    private float timeElapsed;
    private Action NextMove;
    private GridViewer gridViewer = new GridViewer();

    public void Move()
    {
        NextMove?.Invoke();
        Debug.Log("ActualPos: " + gridViewer.GetGridPosition().x + "-" + gridViewer.GetGridPosition().y + ".");
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
