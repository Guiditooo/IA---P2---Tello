using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Grid Related")]
    [SerializeField] private Vector2Int startingGridPos = default;

    [Header("Movement Related")]
    [SerializeField] private float movementTime = 0.25f; // Reemplazar por el tiempo del TimeManager

    private Movement movement = new Movement();
    private float timeElapsed;

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


}
