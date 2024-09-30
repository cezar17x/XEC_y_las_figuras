using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTM : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fastMoveSpeed = 15f;
    public LayerMask wallLayer; 
    private Vector2 direction;
    public bool isMoving;

    void Update()
    {
        HandleSwipe();
    }

    private Vector2 startTouchPosition;

    void HandleSwipe()
    {
        if (Input.touchCount > 0 && !isMoving)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position; // Almacena la posición inicial
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - startTouchPosition;

                if (swipeDelta.magnitude > 50f) // Ajusta el umbral
                {
                    direction = swipeDelta.normalized;
                    LaunchRayAndMove();
                }
            }
        }
    }

    void LaunchRayAndMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, wallLayer);
        Debug.DrawLine(transform.position, hit.point, Color.red);
        if (hit.collider != null)
        {
            // Mueve al jugador hacia el punto de colisión
            Vector2 targetPosition = hit.point;

            // Inicia la corrutina para mover al jugador
            StartCoroutine(MoveToTarget(targetPosition));
        }
    }

    System.Collections.IEnumerator MoveToTarget(Vector2 targetPosition)
    {
        isMoving = true;

        while ((Vector2)transform.position != targetPosition)
        {
            // Mueve rápidamente hacia el objetivo
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, fastMoveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}