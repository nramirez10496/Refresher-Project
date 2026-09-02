using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //REFERENCES
    Rigidbody rb;
    [SerializeField] Animator animator;

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
        animator.SetFloat("walkSpeed", movementVector.magnitude);//update walk float for animations
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
    public void OnMovement(InputAction.CallbackContext ctx)
    {
        Vector2 inputVector = ctx.ReadValue<Vector2>();
        movementVector = new Vector3(inputVector.x,0, inputVector.y);

        transform.forward = movementVector.normalized;//set forward direction
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementVector * moveSpeed, ForceMode.Acceleration);

    }
}
