using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGraph : MonoBehaviour
{
    [SerializeField] GameObject bolitaPrefab;
    [SerializeField] int totalPoints = 10;
    [SerializeField] float distanceFactor;
    private GameObject[] allPoints;
    [SerializeField] float amplitude;
    [SerializeField] LineRenderer lineRenderer;

    private void Start()
    {
        allPoints = new GameObject[totalPoints];
        for (int i = 0; i < totalPoints; i++)
        {
            allPoints[i] = Instantiate(bolitaPrefab, transform);
        }
    }
    private void Update()
    {
        for (int i = 0; i < allPoints.Length; i++)
        {
            float x = i * distanceFactor;
            float y = F(x);

            allPoints[i].transform.localPosition = new Vector3(x, y, 0);
        }
        float F(float x) => amplitude * Mathf.Sin(x + Time.time);
    }
}
