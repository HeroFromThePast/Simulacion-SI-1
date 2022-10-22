using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] Transform target;
    [Range(0, 1)][SerializeField] float normalizedTime;
    [SerializeField] float duration = 1;

    float currentTime = 0f;
    Vector3 initialPos;
    Vector3 finalPos;
    [SerializeField] Color initialColor, finalColor;
    SpriteRenderer spriteRenderer;
    [SerializeField] AnimationCurve curve;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartTween();
    }

    void Update()
    {
        normalizedTime = currentTime / duration;
        transform.position = Vector3.Lerp(initialPos, target.transform.position, curve.Evaluate(normalizedTime));
        spriteRenderer.color = Color.Lerp(initialColor, finalColor, curve.Evaluate(normalizedTime));
        Color.Lerp(finalColor, initialColor, normalizedTime);
        currentTime += Time.deltaTime;

        /* if(normalizedTime >= 1)
         {
             Debug.Log("Tween completed");
         }
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
        
    }

    void StartTween()
    {
        currentTime = 0f;
        initialPos = transform.position;
        finalPos = target.transform.position;
    }
}
