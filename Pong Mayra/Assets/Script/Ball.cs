using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //M,W Class
    //Global Variables
    public Rigidbody2D rbBall; //declare Rigidbody2D variable,set in inspector via drag and dropping 

    public float force = 200; //declare and set force variable 

    private float xDir;
    private float yDir;

    public bool inPlay; // set to true/false if ball is in Play,set in Inspector 
    // Start is called before the first frame update
     //Ball starting position, set in Inspector 

    //Start is called before first frame update 
    void Start()
    {
        //Debug.Log("Hello World");
        Launch(); // call launch function at start
        //check if Ball is in Play 
        void update ();
        { 
            //if (inPlay == false)// if ball is Not in Play
         }
        {
            transform.position = ballStartPos;
            Launch();
        }
        {
            void Launch();
        }
        Vector3 direction = new Vector3(0, 0, 0);
        xDir = Random.Range(0, 2);
        //Debug.Log("xDir = "xDir);
        if (xDir == 0)
        
        {
            direction.x = -1;
        } else if ( xDir == 1)
        {
            direction.x = 1;
        }
        yDir = Random.Range(0, 2);
        if(yDir == 0)
        {
            direction.y = -1; 
        }
        else if (yDir == 1)
        {
            direction.y = 1;
        }
         //add force movement 
         rbBall.AddForce(direction * force);
        inPlay = true;
    }
    //EVENTS UPOM VOLLISION
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Left Wall" || collision.gameObject.name == "Right Wall")
        {
            //Debug.Log("collided with Left Wall")
            rbBall.Velocity = Vector3.zero;
            inPlay = false; 
        }
    }
    // Update is called once per frame
    void Update()
    { 
        if(inPlay == False)
        {
            transform.position = ballStartPos;
            Launch(); 
        }
    }
}
