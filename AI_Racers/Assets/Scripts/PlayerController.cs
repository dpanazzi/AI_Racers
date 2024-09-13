using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float ForwardMove;
    private float ForwardSpeed;
    public float Rotate;
    private float RotateSpeed;
    private bool  IsReverse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // ForwardSpeed is slower if in reverse
        IsReverse = Input.GetAxis("Vertical") < 0; // if input < 0, it goes backwards
        ForwardSpeed = IsReverse ? 5 : 20;
        
        /* sets players movement direction based on input. Because input is only -1 to 1, you must  
          multiply input by speed */
        Rotate = Input.GetAxis("Horizontal") * RotateSpeed;
        ForwardMove =  Input.GetAxis("Vertical") * ForwardSpeed;
        
        // translates player based on what user inputed * speed
        transform.Translate(Vector3.forward * Time.deltaTime * ForwardMove);

        RotateSpeed = ForwardMove * 2;// turning is relative to the car's speed (car can't turn while stopped)
        transform.Rotate(Vector3.up, Time.deltaTime * Rotate);
    }
}
