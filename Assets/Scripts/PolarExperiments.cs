using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;
    [SerializeField] float angularSpeed;
    [SerializeField] float angularAccel;
    [SerializeField] float radialSpeed;
    [SerializeField] float radialSAccel;
    [SerializeField] Transform bolita;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angleDeg += angularSpeed * Time.deltaTime;
        radius += radialSpeed * Time.deltaTime;
 
        bolita.position = PolarToCartesian(radius, angleDeg);

        Debug.DrawLine(Vector3.zero, bolita.position);
    }

    private Vector3 PolarToCartesian(float radius, float angle)
    {
        float x = radius * Mathf.Cos(angleDeg * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angleDeg * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }
}
