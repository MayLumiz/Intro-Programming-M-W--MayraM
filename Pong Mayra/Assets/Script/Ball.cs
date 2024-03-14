using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Global Variables
    public Rigidbody2D rbBall; // Rigidbody2D variable for the ball

    public float force = 200; // Force variable for launching the ball

    private Vector3 ballStartPos; // Starting position of the ball
    private bool inPlay = false; // Boolean to check if the ball is in play

    // Start is called before the first frame update
    void Start()
    {
         rbBall = GetComponent<Rigidbody2D>(); // Assign the Rigidbody2D component to rbBall
        ballStartPos = transform.position; // Store the starting position of the ball
        Launch(); // Call the Launch function to start the ball movement
    }

    // Function to launch the ball
    void Launch()
    {
        // Reset the position of the ball
        transform.position = ballStartPos;

        // Generate random direction for the ball
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // Apply force to the ball in the given direction
        rbBall.AddForce(direction * force);

        // Set inPlay flag to true
        inPlay = true;
    }

    // Event triggered upon collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball collided with the left or right wall
        if (collision.gameObject.CompareTag("LeftWall") || collision.gameObject.CompareTag("RightWall"))
        {
            // Reset the velocity of the ball
            rbBall.velocity = Vector2.zero;

            // Set inPlay flag to false
            inPlay = false;

            // Relaunch the ball
            Launch();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the ball is not in play
        if (!inPlay)
        {
            // Reset the position of the ball
            transform.position = ballStartPos;
        }
    }
}
