using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask isGround;
    bool grounded;

    void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update() {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGround);

        CheckInput();
        SpeedControl();

        // Handle drag
        if (grounded) 
            rb.drag = groundDrag;
        else 
            rb.drag = 0;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void CheckInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput =Input.GetAxisRaw("Vertical");

        // Check when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded) {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        // On ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        // In air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    void SpeedControl() 
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limit
        if(flatVelocity.magnitude > moveSpeed) {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    void Jump() 
    {
        // Reset Y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }
}
