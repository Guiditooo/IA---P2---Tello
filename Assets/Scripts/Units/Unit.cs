using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * Esto contiene la funcionalidad de cada unidad.
 * Realiza el la eleccion del siguiente movimiento.
 * Realiza el movimiento.
 * --- DEBE TENER UNA SUSCRIPCION A UN EVENTO QUE LE DIGA CUANDO MOVERSE (TIME MANAGER) ---
 * --- AVERIGUAR COMO HACER PARA MANEJAR LA POSICION DEL GRIDVIEWER SIN PASAR POR MOVEMENT ---
***/

public class Unit : MonoBehaviour
{
    [Header("Grid Related")]
    [SerializeField] private Vector2Int startingGridPos = default;

    [Header("Movement Related")]
    [SerializeField] private float movementTime = 0.25f; // Reemplazar por el tiempo del TimeManager

    private float timeElapsed;
    private Vector2Int gridPos;
    private GridViewer gridViewer;
    private Movement movement;

    /*private void Awake()
    {
        //Suscribirse al evento de cambiar de direccion para moverse
    }
    */
    private void Start()
    {
        gridViewer = new GridViewer(gridPos);
        movement = new Movement(gridViewer);
    }

    private void Update() //Reemplazar por el "update del TimeManager"
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > movementTime)
        {
            timeElapsed -= movementTime;
            movement.SetNextMovement((Movement.Movement_Direction)Random.Range(0,6));
            movement.Move();
            gridPos = gridViewer.GetGridPosition();
            UpdateVisualPosition();
        }
    }

    public void SetPosition(Vector2Int newPos)
    {
        gridPos = newPos;
    }
    public void SetPosition(int x, int y)
    {
        gridPos = new Vector2Int(x,y);
    }
    public Vector2Int GetPosition() => gridPos;

    private void UpdateVisualPosition()
    {
        UnitPositionHelper UPH = GridManager.GetUnitPositionHelper();
        transform.position = new Vector3(UPH.padding + UPH.tileSize * gridPos.x, UPH.padding + UPH.tileSize * gridPos.y, 0);
    }

}
