using System;
using UnityEngine;

[Serializable]
public struct MyVector2D 
{
    public float x, y;

    public float magnitude => Mathf.Sqrt(x * x + y * y);

    public MyVector2D normalized
    {
        get
        {
            float m = magnitude;
            if (m <= 0.0001f)
            {

                return new MyVector2D(0,0);
            }

           return  new MyVector2D(x / m, y / m);
        }
    }

    public MyVector2D(float x, float y)
    {
        this.x = x;
        this.y = y; 
    }

    public void Normalize()
    {
        float m = magnitude;
        float ratio = 0.0001f;
        if(m <= ratio)
        {
            x = 0; y = 0;
            return;
        }
        x = x/m; y = y/m;
    }

    public MyVector2D Sum(MyVector2D a)
    {
        return new MyVector2D (this.x + a.x, this.y + a.y);
    }
    public MyVector2D Sub(MyVector2D a)
    {
        return new MyVector2D(this.x - a.x, this.y - a.y);
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y), color);
    }

    public void Draw(MyVector2D newOrigin, Color color)
    {
        Vector3 start = new Vector3(newOrigin.x, newOrigin.y);
        Vector3 end = new Vector3(newOrigin.x + x, newOrigin.y + y);
        Debug.DrawLine(start, end, color);
    }
    /*
    public void Draw(MyVector2D newOrigin, MyVector2D newEnd, Color color)
    {
        Debug.DrawLine(new Vector3(newOrigin.x, newOrigin.y), new Vector3(newEnd.x, newEnd.y), color);
    }
    */
    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x + b.x, a.y + b.y);
    }

    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x - b.x, a.y - b.y);
    }

    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(a.x * b, a.y *  b);
    }

    public static MyVector2D operator *(float b, MyVector2D a)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
    public static MyVector2D operator /(MyVector2D a, float b)
    {
        return new MyVector2D(a.x / b, a.y / b);
    }

    public override string ToString()
    {
        return $"[{x}, {y}]";
    }
}
