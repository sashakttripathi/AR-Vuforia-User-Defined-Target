using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Electrons : MonoBehaviour
{
    public Transform nucleusTransform;

    public float radius = 2.0f;
    public float speed = 5.0f;
    public float speedFactor = 100f;

    private float currentSpeed, currentRadius;

    private void Start()
    {
        currentRadius = radius;
        currentSpeed = speed;
    }

    private void Update()
    {
        var newPos = (transform.position - nucleusTransform.position).normalized * currentRadius;
        newPos += nucleusTransform.position;
        transform.position = newPos;

        transform.RotateAround(nucleusTransform.position, nucleusTransform.up, currentSpeed * Time.deltaTime * speedFactor);
    }

    public void ChangeSpeed(float sliderValue)
    {
        currentSpeed = (speed * sliderValue);
    }

    public void ChangeRadius(float sliderValue)
    {
        currentRadius = radius * sliderValue;
    }
}
