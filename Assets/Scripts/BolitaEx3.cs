using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolitaEx3 : MonoBehaviour
{
    MyVector2D ballPosition;
    MyVector2D displacement;
    MyVector2D objectivePosition;
    [SerializeField] MyVector2D acceleration;
    [SerializeField] Camera cam;
    [SerializeField] MyVector2D velocity;
    [SerializeField] Transform objective;
   
    void Start()
    {
        ballPosition = new MyVector2D(transform.position.x, transform.position.y);

    }

    private void FixedUpdate()
    {
        Move();
        
        objectivePosition = new MyVector2D(objective.position.x, objective.position.y);
        acceleration = objectivePosition - ballPosition;
    }

    void Update()
    {
        ballPosition.Draw(Color.blue);
        displacement.Draw(ballPosition, Color.red);
        velocity.Draw(ballPosition, Color.magenta);
        acceleration.Draw(ballPosition, Color.yellow);

    }

    public void Move()
    {
        //displacement = velocity * Time.deltaTime;
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        ballPosition = ballPosition + velocity * Time.fixedDeltaTime;

        transform.position = new Vector3(ballPosition.x, ballPosition.y);
        Debug.Log("Moving");
    }
}
