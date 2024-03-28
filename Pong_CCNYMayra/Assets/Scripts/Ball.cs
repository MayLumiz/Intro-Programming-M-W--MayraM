using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   
    public Rigidbody2D rb2d; // control ball physics 
    public float maxInitialAngle = 0.67f; // mac angle for intial direction
    public float moveSpeed = 1f; // speed of the ball
    public float maxStarty = 4f; // max y for start position
    public float speedMultiplier = 1.1f; // speed increase on paddle hit
    private float startX = 0f; // start x position

    private void Start()
    {
        InitialPush(); // start ball movement 
        GameManager.instance.onReset += ResetBall; // reset on event 
    }
    private void ResetBall() // reset ball for new round 
    {
      ResetBallPosition();
      InitialPush(); // start moving again
    }
    private void InitialPush() // intial movement direction
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right; // choose direction
        
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle); // random y angle 
        rb2d.velocity = dir * moveSpeed; // apply velocity 
    }
    private void ResetBallPosition() // set ball to start position
    {
       float posY = Random.Range(-maxStarty, maxStarty); // random start y 
       Vector2 position = new Vector2(startX, posY);
       transform.position = position;  // move ball
    }
    private void OnTriggerEnter2D(Collider2D collision) // dectect score zone 
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>(); // notify score 
        if(scoreZone)
        {
            GameManager.instance.OnScoreZoneReached(scoreZone.id); // detect paddle hit 
            
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle)
        {
            rb2d.velocity *=speedMultiplier; // increase speed
        }
    }
}
