using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxForwardSpeed;
    [SerializeField] private float maxReverseSpeed;
    [SerializeField] private float accelerationSpeed; // Acceleration / Decceleration and Reversing
    [SerializeField] private float rotateSpeed; // Turning

    private float _accel;
    private float _rotate;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MoveRotation(Quaternion.Euler(0, rotateSpeed * _rotate * Time.fixedDeltaTime, 0));
        
        _rb.velocity += (_accel * Time.fixedDeltaTime * accelerationSpeed * transform.forward);

        Vector3 v = _rb.velocity;
        _rb.velocity = Math.Min(v.magnitude, maxForwardSpeed) * v.normalized;
    }

    void OnTurn(InputValue value)
    {
        _rotate = value.Get<float>();
    }

    void OnAccelerate(InputValue value)
    {
        _accel = value.Get<float>();
    }
}
