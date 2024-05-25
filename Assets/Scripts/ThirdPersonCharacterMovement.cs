using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterMovement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraPosition;

    // Movement and rotation
    float vertical, horizontal;
    Vector3 direction;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothvelocity;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;


    }

    private void FixedUpdate()
    {
        if (direction.magnitude >= 0.1f)
        {
            // Rotate the player
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraPosition.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothvelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the player
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDirection.normalized * moveSpeed);
        }
    }
}
