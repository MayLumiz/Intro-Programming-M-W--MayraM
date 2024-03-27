using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
    public Rigidbody2D rb2d; // for physics-based movement 
    public int id; // identifies paddles for player1 or player2 
    public float movespeed = 2f; // movement speed 

    private Vector3 startPosition; // starting position for resetting

    private void Start()
    {
        startPosition = transform.position; // save start position
        GameManager.instance.onReset += ResetPosition; // Subscribe!!! to reset event :3
    }
    private void ResetPosition()
    {
        transform.position = startPosition; // Reset to start position
    }

    private void Update()
    {
        float movement = ProcessInput(); // Get input 
        Move(movement); // move based on input
    }
    private float ProcessInput() // determine movement direction
    {
        float movement = 0f;
        switch (id)
        {
         case 1:
             movement = Input.GetAxis("MovePlayer1"); // inpute for player1
             break;
         case 2:
             movement = Input.GetAxis("MovePlayer2"); // inpute for player2
             break;
        }
        return movement;
    }
    private void Move(float movement) // apply movement 
    {
        Vector2 velo = rb2d.velocity;
        velo.y = movespeed * movement; // set vertical speed
        rb2d.velocity = velo; // apply rigidbody 
    }
}
