using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    //Speed (How fast the player will navigate on our game)
    public int moveSpeed;

    //RigidBody (Handles Physics, Makes our Player Moves) 
    public Rigidbody2D rigidBody;

    //Dictates where the player is moving
    private Vector2 movementInput;

    //Access our Animator to play animations
    public Animator anim;

    //Counts coins collected
    public int coinsCount;

    //Player's Health Points
    public int healthPoints;

    public TMP_Text coinText;

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
        //if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Backward");
        //}

        //if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Forward");
        //}

        //if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Left");
        //}

        //if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Right");
        //}

        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    anim.enabled = false;
        //}

        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinsCount++;
            Destroy(collision.gameObject);
            coinText.text = "COINS:" + coinsCount.ToString();
        }
        if (collision.CompareTag("Speed"))
        {
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }
        if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
        }
    }
}
