using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    MyVector2D ballPosition;
    MyVector2D displacement;

    [SerializeField] MyVector2D acceleration;
   [Range(0f, 1f)] [SerializeField] float damping;
    [SerializeField] Camera cam;
    [SerializeField] MyVector2D velocity;
    [SerializeField] int accelerationState = 1;
   
    void Start()
    {
        ballPosition = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move();

    }

    void Update()
    {
        ballPosition.Draw(Color.blue);
        displacement.Draw(ballPosition, Color.red);
        velocity.Draw(ballPosition, Color.magenta);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(accelerationState > 4)
            {
                accelerationState = 1;
            }
            else accelerationState++;

        }

        switch (accelerationState)
        {
            case 1:
                acceleration.y = -9.8f;
                acceleration.x = 0;
                break;
            case 2:
                acceleration.y = 0 ;
                acceleration.x = 9.8f;
                break;
            case 3:
                acceleration.y = 9.8f;
                acceleration.x = 0;
                break;
            case 4:
                acceleration.y = 0;
                acceleration.x = -9.8f;
                break;

        }

    }

    public void Move()
    {
        //displacement = velocity * Time.deltaTime;
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        ballPosition = ballPosition + velocity * Time.fixedDeltaTime;

        if (ballPosition.x > cam.orthographicSize)
        {
            velocity.x *= -1;
            ballPosition.x = cam.orthographicSize;
            velocity *= damping;
        }
        else if (ballPosition.x < -cam.orthographicSize)
        {
            velocity.x *= -1;
            ballPosition.x = -cam.orthographicSize;
            velocity *= damping;
        }

        if (ballPosition.y > cam.orthographicSize)
        {
            velocity.y *= -1;
            ballPosition.y = cam.orthographicSize;
            velocity *= damping;
        }
        else if (ballPosition.y < -cam.orthographicSize)
        {
            velocity.y *= -1;
            ballPosition.y = -cam.orthographicSize;
            velocity *= damping;
        }
        transform.position = new Vector3(ballPosition.x, ballPosition.y);
        Debug.Log("Moving");
    }
}
