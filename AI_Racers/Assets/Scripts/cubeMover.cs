using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Rigidbody myRigidbody;
    public int currentCheckPoint;
    public int currentLap;
    public int totalCheckpoints;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector3(-5, myRigidbody.velocity.y, myRigidbody.velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector3(5, myRigidbody.velocity.y, myRigidbody.velocity.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, 5);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, -5);
        }

    }
}
