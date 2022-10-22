using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations2 : MonoBehaviour
{
    [SerializeField] private float amplitud = 1;
    [SerializeField] private float periodo = 1;
    Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }
    private void Update()
    {
        float xPos = Mathf.Sin(5f);
        transform.position = initialPos + new Vector3(xPos, 0, 0);
    }
}
