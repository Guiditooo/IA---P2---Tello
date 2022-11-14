using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

/***
 * Accion de movimiento de una unidad.
 * Puede moverse tanto para arriba, abajo, izquierda, derecha, asi como no hacerlo.
 * Utiliza el GridViewer para moverse sobre la grilla.
***/

public class Movement
{
    public enum Movement_Direction
    {
        None, Up, Right, Down, Left
    };

    private Movement_Direction nextDirection = default;
    private Action NextMove;
    private GridViewer gridViewer = null;
    public Movement(GridViewer newGridViewer)
    {
        gridViewer = newGridViewer;
    }

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

    public void Move()
    {
        NextMove?.Invoke();
        //Debug.Log("ActualPos: " + gridViewer.GetGridPosition().x + "-" + gridViewer.GetGridPosition().y + ".");
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
