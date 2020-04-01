using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 6.0f;    public float jumpSpeed = 8.0f;    public float rotateSpeed = 90f;    public Rigidbody rb;

    // am i on the ground?
    private bool isGrounded = false;

    void Start()    {
        rb = GetComponent<Rigidbody>();    }    void Update()    {

        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0f);
        transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;


        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Plane"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Plane"))
        {
            isGrounded = false;
        }
    }
}
