using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parte1 : MonoBehaviour
{
    [SerializeField] MyVector2D vector1 = new MyVector2D(-2, 3);
    [SerializeField] MyVector2D vector2 = new MyVector2D(3, 4);
    [SerializeField] MyVector2D vector3 = new MyVector2D(1,1);
    [SerializeField] [Range(0,1)] float escalar;

    private void Start()
    {
        MyVector2D a = new MyVector2D(2, 3 );
        MyVector2D b = new MyVector2D(4, 5);
        MyVector2D d = a.Sum(b);

        Vector2 au = new Vector2(2, 3);
        Vector2 bu = new Vector2(4, 5);
        Vector2 du = au + bu;
    }

    private void Update()
    {
        
        vector1.Draw(Color.red);
        vector2.Draw(Color.green);
        MyVector2D result = (vector2 - vector1) * escalar;
        // result.Draw(Color.yellow);
        MyVector2D result3 = vector1 + result;
        result3.Draw(Color.blue);
        result.Draw(vector1, Color.yellow);

       // MyVector2D result2 = result * escalar;
        //result2.Draw(Color.blue);
        /*
        MyVector2D result = vector1 + vector2;
        result.Draw(Color.yellow);
        */




    }
}
