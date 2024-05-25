using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotateSpeed = 3;
    [SerializeField] private Transform center;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0), Space.Self);   // rotate around X

        //transform.RotateAround()
    }
}
