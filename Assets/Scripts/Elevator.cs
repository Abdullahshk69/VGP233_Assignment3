using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private int currentIndex;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float force;

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.1f)
        {
            if (currentIndex == 0)
            {
                if (gameObject.transform.childCount > 0)
                {
                    GetComponentInChildren<CharacterMovement>().ApplyForce(new Vector3(0, force, 0));
                }
            }

            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 0;
            }
        }

        // Moves towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].transform.position, moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
