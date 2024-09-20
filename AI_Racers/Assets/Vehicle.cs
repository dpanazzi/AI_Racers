using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float maxForwardSpeed;
    [SerializeField] private float maxReverseSpeed;
    [SerializeField, Range(2, 20)] private float acceleration;
    [SerializeField, Range(1, 10)] private float braking;
    [SerializeField, Range(10, 100)] private float handling;
    [SerializeField] private GameObject[] guideWheels;

    private float _speed = 0;
    private float _steering = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject guideWheel in guideWheels)
        {
            guideWheel.transform.rotation = Quaternion.Euler(0, _steering, 0);
        }

        _steering -= Math.Min(5, Math.Abs(_steering)) * Math.Sign(_steering);
        _speed -= Math.Min(_steering / handling * Time.deltaTime, Math.Abs(_speed)) * Math.Sign(_speed);
        transform.position += _speed * Time.deltaTime * guideWheels[0].transform.forward;
    }

    /// <summary>
    /// Accelerates the vehicle for this frame.
    /// </summary>
    public void Accelerate(float amount)
    {
        _speed += amount * acceleration * Time.deltaTime;
        _speed = Math.Min(_speed, maxForwardSpeed);
    }

    /// <summary>
    /// Brakes the vehicle for this frame
    /// </summary>
    public void Brake(float amount)
    {
        _speed -= amount * braking * Time.deltaTime;
        _speed = Math.Max(_speed, maxReverseSpeed);
    }

    public void Steer(float amount)
    {
        _steering = Mathf.Clamp(_steering + (amount * handling * Time.deltaTime), -45, 45);
    }
}
