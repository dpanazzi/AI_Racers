using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField, Range(2, 20)] private float acceleration;
    [SerializeField, Range(1, 10)] private float braking;
    [SerializeField, Range(1, 30)] private float handling;
    [SerializeField] private GameObject[] guideWheels;
    
    private Rigidbody _rb;
    private float _steering = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        foreach (GameObject guideWheel in guideWheels)
        {
            guideWheel.transform.localRotation = Quaternion.Euler(0, _steering, 0);
        }
    }

    /// <summary>
    /// Accelerates the vehicle for this frame.
    /// </summary>
    public void Accelerate(float accelAmount)
    {
        if (_rb.velocity.magnitude > maxSpeed) return;
        
        _rb.AddForce(accelAmount * acceleration * _rb.mass * transform.forward);
    }

    /// <summary>
    /// Brakes the vehicle for this frame
    /// </summary>
    public void Brake(float brakeAmount)
    {
        if (_rb.velocity.magnitude > maxSpeed) return;
        
        _rb.AddForce(brakeAmount * braking * _rb.mass * transform.forward);
    }

    public void Steer(float steerAmount)
    {
        Vector3 forward = transform.forward;
        
        _steering = steerAmount * handling;
        _rb.AddForce(-_rb.mass / handling * acceleration * forward);
        float angleDiff = Vector3.Angle(forward, _rb.velocity);
        float reverseTurn = angleDiff > 90 ? -1 : 1;
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(0, steerAmount * handling * _rb.velocity.magnitude * reverseTurn / 2000, 0));
    }
}
