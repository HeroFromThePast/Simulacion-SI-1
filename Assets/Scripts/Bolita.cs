using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    MyVector2D ballPosition;
    [SerializeField] MyVector2D displacement;
    [SerializeField] Camera cam;
   
    void Start()
    {
        ballPosition = new MyVector2D(transform.position.x, transform.position.y);
    }

  
    void Update()
    {
        ballPosition.Draw(Color.blue);
        displacement.Draw(ballPosition, Color.red);
    }

    public void Move()
    {
        ballPosition = ballPosition + displacement;
        if(ballPosition.x > cam.orthographicSize)
        {
            displacement.x *= -1;
            ballPosition.x = cam.orthographicSize;
        }
        else if (ballPosition.x < -cam.orthographicSize)
        {
            displacement.x *= -1;
            ballPosition.x = -cam.orthographicSize;
        }

        if (ballPosition.y > cam.orthographicSize)
        {
            displacement.y *= -1;
            ballPosition.y = cam.orthographicSize;
        }
        else if (ballPosition.y < -cam.orthographicSize)
        {
            displacement.y *= -1;
            ballPosition.y = -cam.orthographicSize;
        }
        transform.position = new Vector3(ballPosition.x, ballPosition.y);
        Debug.Log("Moving");
    }
}
