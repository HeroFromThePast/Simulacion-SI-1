using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    MyVector2D ballPosition;
    MyVector2D displacement;
    [SerializeField] Camera cam;
    [SerializeField] MyVector2D velocity;
   
    void Start()
    {
        ballPosition = new MyVector2D(transform.position.x, transform.position.y);
    }

  
    void Update()
    {
        ballPosition.Draw(Color.blue);
        displacement.Draw(ballPosition, Color.red);
        Move();
    }

    public void Move()
    {
        //displacement = velocity * Time.deltaTime;
        ballPosition = ballPosition + velocity * Time.deltaTime;

        if (ballPosition.x > cam.orthographicSize)
        {
            velocity.x *= -1;
            ballPosition.x = cam.orthographicSize;
        }
        else if (ballPosition.x < -cam.orthographicSize)
        {
            velocity.x *= -1;
            ballPosition.x = -cam.orthographicSize;
        }

        if (ballPosition.y > cam.orthographicSize)
        {
            velocity.y *= -1;
            ballPosition.y = cam.orthographicSize;
        }
        else if (ballPosition.y < -cam.orthographicSize)
        {
            velocity.y *= -1;
            ballPosition.y = -cam.orthographicSize;
        }
        transform.position = new Vector3(ballPosition.x, ballPosition.y);
        Debug.Log("Moving");
    }
}
