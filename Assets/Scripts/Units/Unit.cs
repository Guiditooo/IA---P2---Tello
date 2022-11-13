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

    private Movement movement = new Movement();
    private float timeElapsed;
    private Vector2Int pos;//esto esta adentro de movement tengo que buscar una manera de sacarlo de ahi

    private void Awake()
    {
        
        //Suscribirse al evento de cambiar de direccion para moverse
    }

    private void Update() //Reemplazar por el "update del TimeManager"
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > movementTime)
        {
            timeElapsed -= movementTime;
            movement.SetNextMovement((Movement.Movement_Direction)Random.Range(0,6));
            movement.Move();
        }
    }

    public void SetPosition(Vector2Int newPos)
    {
        pos = newPos;
    }
    public void SetPosition(int x, int y)
    {
        pos = new Vector2Int(x,y);
    }

}
