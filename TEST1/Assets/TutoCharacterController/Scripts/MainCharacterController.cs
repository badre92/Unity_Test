using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class responsible for main character controlls :
/// Character is able to : Move(Walk and Sprint) and Jump.
/// Show And Hide cursor with Right Click
/// WASD to move, Maintain left shift to run
/// To Change default inputs : Edit => Project Settings => Input
/// </summary>
public class MainCharacterController : MonoBehaviour
{
    private float walkSpeed = 5.0f;
    private float runSpeed = 10.0f;
    private float jumpSpeed = 5.0f;
    private bool mouseLock;

    // Use this for initialization
    void Start()
    {
        // Hide the cursor to begin with
        Cursor.lockState = CursorLockMode.Locked;
        mouseLock = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        ShowMouse();
    }

    // Get input and translate character (Walk and Sprint)
    private void Move()
    {
        float currentSpeed = walkSpeed; 
        // Check if the player sprints
        if (Input.GetKey(KeyCode.LeftShift)) // GetKey returns true while the user hold down the key
        {
            currentSpeed = runSpeed;
        }

        float xMove = Input.GetAxis("Horizontal") * currentSpeed;
        float zMove = Input.GetAxis("Vertical") * currentSpeed;
        xMove *= Time.deltaTime;
        zMove *= Time.deltaTime;
        // Moving
        this.transform.Translate(xMove, 0, zMove);
    }

    // Go up
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // GetKey returns true when the user press down the key
        {
            this.GetComponent<Rigidbody>().velocity += jumpSpeed * Vector3.up;
        }
    }

    // Show the cursor
    private void ShowMouse()
    {
        if (Input.GetMouseButtonDown(1)) // Right click down
        {
            mouseLock = !mouseLock;
            if (mouseLock)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
