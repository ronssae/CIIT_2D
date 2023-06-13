using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Speed (How fast the player will navigate on our game)
    public float moveSpeed;
    //RigidBody (Handles Physics, Makes our Player Moves) 
    public Rigidbody2D rigidBody;
    //Dictates where the player is moving
    private Vector2 movementInput;
    //Access our Animator to play animations
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //gets component on the player and stores it on the variables
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Backward");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("Back Idle");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("Forward");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetTrigger("Front Idle");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Left");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("Left Idle");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Right");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetTrigger("Right Idle");
        }
    }
    private void FixedUpdate() //Fixed Update for Physics Calculations
    {
        //Makes our player move
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        //if press WASD = to Vector 2 values
        movementInput = inputValue.Get<Vector2>();
    }

}
