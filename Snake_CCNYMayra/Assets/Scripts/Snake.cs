using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    public GameObject kirbyPrefab; // Prefab for Kirby
    public float speed = 1.0f;
    public float rotationSpeed = 50.0f;
    public List<Transform> bodyParts = new List<Transform>();
    public float minDistance = 0.25f;
    public int beginSize;

    private float distance;
    private Transform curBodyPart;
    private Transform prevBodyPart;

    void Start()
    {
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
            
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float curSpeed = speed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            curSpeed *= 2.0f; // Double speed if moving up
        }

        transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        if (bodyParts.Count > 0)
        {
            bodyParts[0].position = transform.position;

            for (int i = 1; i < bodyParts.Count; i++)
            {
                curBodyPart = bodyParts[i];
                prevBodyPart = bodyParts[i - 1];
                distance = Vector3.Distance(prevBodyPart.position, curBodyPart.position);
                Vector3 newPos = prevBodyPart.position;
                newPos.y = transform.position.y;
                float T = Time.deltaTime * distance / minDistance * curSpeed;
                if (T > 0.5f)
                {
                    T = 0.5f;
                }
                curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
                curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
            }
        }
    }

    public void AddBodyPart()
    {
        Transform newPart = (Instantiate(kirbyPrefab, bodyParts[bodyParts.Count - 1].position, Quaternion.identity) as GameObject).transform;
        newPart.SetParent(transform);
        bodyParts.Add(newPart);
    }
}
