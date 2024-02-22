using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rbPaddle;

    public bool isPlayer1;

    public float paddleSpeed = 0.05f;
    void Start()
    {
        //debug.Log("Paddle Script! Yay!");
        //paddleSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            Player1Control();
        }
        else
        {
            PLayer2Control();
        }
    }
    void Player1Control()
    {
        Vector3 newPos = transform.position;

        if(newPos.y <= 4.1f && newPos.y >= -4.1f)
        {
            if (Input.GetKey(KyCode.W))
            {
                newPos.y += paddleSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                newPos.y -= paddleSpeed;
            }
            trasform.position = newPos;
        }
    }
    void Player2Control()
    {
        Vector3 newPos = transform.position;
        if (newPos.y <= 4.1f && newPos.y >= -4.1f)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                newPos.y += paddleSpeed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                newPos.y -= paddleSpeed;
            }
            transform.position = newPos;
        }
        if (newPos.y >= 4.1f)
        {
            newPos.y = 4;
            transform.position = newPos;
        }
        else if (newPos.y <= -4.1f)
        {
            newPos.y <= -4;
            transform.position = newPos;
        }
    }
}   
