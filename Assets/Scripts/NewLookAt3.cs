using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLookAt3 : MonoBehaviour
{
     Vector3 velocity;
    

     [SerializeField] private float speed = 1;
    
    
    void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();
        velocity = mousePosition - transform.position;
        
        float angle = Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2;
        RotateZ(angle);
        
        if (velocity.magnitude > 1)
        {
            transform.position += velocity * speed * Time.deltaTime;
        }
    }
    public Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
