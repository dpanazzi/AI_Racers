using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject vehiclePrefab;
    [SerializeField] private float maxCamOffset;

    private float _accel = 0f;
    private float _rotate = 0f;
    private Vehicle _vehicle;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(vehiclePrefab, transform.position, Quaternion.identity);
        _vehicle = obj.GetComponent<Vehicle>();
        Debug.Log(_vehicle);
    }

    // Update is called once per frame
    void Update()
    {
        if (_accel > 0)
        {
            _vehicle.Accelerate(_accel);
        }
        else if (_accel < 0)
        {
            _vehicle.Brake(_accel);
        }
        
        _vehicle.Steer(_rotate);

        transform.position = _vehicle.gameObject.transform.position;

        float angleDiff = Mathf.DeltaAngle(transform.rotation.y, _vehicle.transform.rotation.y);
        if (Math.Abs(angleDiff) > 0)
        {
            transform.rotation *= Quaternion.Euler(0, angleDiff, 0);
        }
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
