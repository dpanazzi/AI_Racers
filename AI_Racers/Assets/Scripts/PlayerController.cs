using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vehicle vehicle;

    private float _accel;
    private float _rotate;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(vehicle);
    }

    // Update is called once per frame
    void Update()
    {
        vehicle.Accelerate(Math.Max(0, _accel));
        vehicle.Brake(Math.Max(0, -_accel));
        vehicle.Steer(_rotate);

        transform.position = vehicle.gameObject.transform.position;
    }

    void OnTurn(InputValue value)
    {
        _rotate = value.Get<float>();
    }

    void OnAccelerate(InputValue value)
    {
        _accel = value.Get<float>();
    }

    bool OnGround()
    {
        bool cast = Physics.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Drivable"));
        return cast;
    }
}
