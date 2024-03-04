using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //VOLLEGR NOW IN CLSSS MW

    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right; //decare default movement direction
                                 //Remember the difference b/w Vector2(x,y) & Vector3(x,y,z)
                                 //there is shorthand for Vector2/3 directions.
                                 //In this one, Vector3.right = Vector3(1,0,0), moving it to the RIGHT

    // Start is called before the first frame update
    void Start()
    {
        //OPTION: Randomize the direction of the snake like our Pong Ball when it starts

        //Call MoveSnake() every 300ms(0.3 seconds) to move the snake
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
        //InvokeRepeating("methodName", time, repeatRate)
        //methodName: name of method/function to invoke
        //time: start invoking after n seconds
        //repeatRate: repeat after every n seconds.
    }

    // Update is called once per frame
    void Update()
    {
        //NOTE: if we did movement in update, it would go SUPER FAST, so let's call it on a delay in Start()

        //Change the Snake's direction by calling ChangeDirection(), detecting key presses all the time
        ChangeDirection(); 
    }

    void MoveSnake()
    {
        //In Snake, the snake is ALWAYS moving in some direction, never standing still.
        //MOVE SNAKE HEAD IN A DIRECTION
        transform.Translate(dir);
        //Translate moves the transform property in the direction and distance of the translation,
        //In this case, we are moving in the whatever direction we've set the dir variable to be the distance of that variable

    }

    private void ChangeDirection()
    {
        if(Input.GetKey(KeyCode.RightArrow)) //if the Right Arrow is continuously pressed down, then...
        {
            dir = Vector3.right; //change the direction to RIGHT
            //Debug.Log("direction = right"); //print to console
        }//MOVE LEFT
        else if (Input.GetKey(KeyCode.LeftArrow)) //if the Left Arrow is continuously pressed down, then...
        {
            dir = Vector3.left; //change the direction to LEFT
                                //NOTE: this could also be written as dir = - Vector3.right, "-right" = left
                                //Debug.Log("direction = left"); //print to console
        }//MOVE UP
        else if (Input.GetKey(KeyCode.UpArrow)) //if the Up Arrow is continuously pressed down, then...
        {
            dir = Vector3.up; //change the direction to UP
            //Debug.Log("direction = up"); //print to console
        }//MOVE DOWN
        else if (Input.GetKey(KeyCode.DownArrow)) //if the Down Arrow is continuously pressed down, then...
        {
            dir = Vector3.down; //change the direction to DOWN
            //Debug.Log("direction = down"); //print to console
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When Snake collides with Food...
        if (collision.gameObject.tag == "Food")
        {
            //Debug.Log("food eaten");
            Destroy(collision.gameObject); //Remove the Food

        }
    }
}