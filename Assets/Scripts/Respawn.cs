using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private Transform checkpoint;

    public void RespawnPlayer()
    {
        rb.velocity = Vector3.zero;
        transform.position = checkpoint.position;
    }

    public void Checkpoint(Transform checkpoint)
    {
        this.checkpoint = checkpoint;
    }
}
