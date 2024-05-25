using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private int currentIndex;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 0;
            }
        }

        // Moves towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].transform.position, moveSpeed);
    }
}
