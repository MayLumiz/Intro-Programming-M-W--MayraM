using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private floot moveSpeed;
    [SerializeField] private bool Player2
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playermove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player2)
        {

        }
        else
        {

        }
    }
    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }
    private void Player2()
    {
        if(ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove
        }
    }
}
