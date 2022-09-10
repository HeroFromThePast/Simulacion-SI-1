using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolitaforces : MonoBehaviour
{
    MyVector2D ballPosition;
    MyVector2D displacement;

    [SerializeField] MyVector2D acceleration;
   [Range(0f, 1f)] [SerializeField] float damping;
    [SerializeField] Camera cam;
    [SerializeField] MyVector2D velocity;
    [SerializeField] MyVector2D gravity;
    [SerializeField] MyVector2D wind;
    [SerializeField] float mass = 1f;
    [SerializeField] bool fluid;
    [Range(0f, 1f)] [SerializeField] float frictionRatio = 1f;
    [Range(0f, 1f)] [SerializeField] float fluidfrictionRatio = 1f;
    MyVector2D NetForce;
    MyVector2D weight;
    MyVector2D normalForce;
    MyVector2D friction;

    void Start()
    {
        ballPosition = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fluido"))
        {
            fluid = true;
        }
    }
    private void FixedUpdate()
    {   
        weight = mass * gravity;

        if (fluid == true)
        {
            if(transform.localScale.y <= 0)
            {
                float frontalArea = transform.localScale.x;
                float rho = 1; //densidad
                float scalar = -0.5f * rho * velocity.magnitude * velocity.magnitude * frontalArea * fluidfrictionRatio;
                friction = scalar * velocity.normalized;                
            }
        }
        else
        {
            friction = (-frictionRatio * weight.magnitude) * velocity.normalized;
        }

        NetForce = gravity + wind + weight + friction;



        AplyForce(NetForce);

        Move();






    }

    

    void Update()
    {
        
        friction.Draw(ballPosition, Color.black);
        ballPosition.Draw(Color.blue);
        displacement.Draw(ballPosition, Color.red);
        velocity.Draw(ballPosition, Color.magenta);
        //NetForce.Draw(ballPosition, Color.cyan);


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

    public void AplyForce(MyVector2D force)
    {
        acceleration = force / mass;
    }

}
