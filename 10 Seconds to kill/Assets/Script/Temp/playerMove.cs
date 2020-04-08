using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMove : MonoBehaviour
{
    public float speedX, speedY;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speedX, 0, Input.GetAxis("Vertical")* speedY);
    }
}
