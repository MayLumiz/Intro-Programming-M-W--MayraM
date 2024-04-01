using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float playerSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector3 newPos = transform.position;
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A pressed");
            newPos.x -= playerSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D is pressed");
            newPos.x += playerSpeed;
        }
    }
}
