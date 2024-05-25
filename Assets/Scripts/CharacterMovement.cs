using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // [SerializeField] private CharacterController characterController;

    [SerializeField] 
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce;

    float horizontalMovement;
    float verticalMovement;

    private bool isGrounded;

    [SerializeField]
    private LayerMask layerMask;

    private Vector2 turn;

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.0f + 0.2f, layerMask);     // 1.0f: Player height dependent on Scale.      0.2f: buffer/leeway

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        //Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.red, 5f);

        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed;

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxisRaw("Mouse Y");

        // transform.localRotation = Quaternion.Euler(0, turn.y, 0);
        rb.MoveRotation(Quaternion.Euler(0, turn.y, 0));

        // characterController.Move(new Vector3(horizontalMovement, 0, verticalMovement));

        //MovePlayer();
    }

    public void MovePlayer()
    {
        rb.AddForce(new Vector3(horizontalMovement, 0, verticalMovement));
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
