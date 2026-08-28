using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //REFERENCES
    Rigidbody rb;

    //MOVEMENT VALUES
    [SerializeField] float moveSpeed = 20.0f;
    [SerializeField] float jumpSpeed = 10.0f;
    Vector3 movementVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movementVector = new Vector3(h, 0, v);

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementVector * moveSpeed, ForceMode.Acceleration);

    }
}
