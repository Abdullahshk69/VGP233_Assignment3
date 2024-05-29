using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraPosition;

    // Movement and rotation
    float vertical, horizontal;
    Vector3 direction;  // Look Direction
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothvelocity;

    // Jump
    private bool isGrounded;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.0f + 0.2f, layerMask);     // 1.0f: Player height dependent on Scale.      0.2f: buffer/leeway
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

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

    public void ApplyForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}
