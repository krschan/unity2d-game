using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2.0f;
    public float reachDistance = 0.5f;

    private int currentPointIndex = 0;

    void Start()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("No hay puntos de patrullaje asignados.");
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector2 direction = (targetPoint.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < reachDistance)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;

            if (currentPointIndex == 0)
            {
                transform.localScale = new Vector3(6, 6, 1);
            }
            else
            {
                transform.localScale = new Vector3(-6, 6, 1);
            }
        }
    }
}
