using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
   
    // gets info from player object
    public GameObject Player;
    private PlayerController PlayerControllerScript;

    // this is the displacement of the camera from the vehicle. this should remain constant
    private Vector3 Offset = new Vector3(0, 10, -12);

    // determines how much the car is tilted away from camera
    public float RotateOffsety;

    // after RotateOffsety reaches this threashold, start rotating cam
    private int RotateOffsetMax = 30;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = FindObjectOfType<PlayerController>(true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //CheckRotateOffset();
       // makes sure camera is behind car
       
        transform.position = Player.transform.position + Offset;
        
    }

    // if car is leaning to the left/right to a certain degree, allow the camera to follow

    //!! UNDER CONSTRUCTION !!
    void CheckRotateOffset()
    {
        //calculates difference between player rotation and camera rotation
        RotateOffsety = (Player.transform.rotation.y - transform.rotation.y) * 180;// the 180 converts to degrees

        if (RotateOffsety > RotateOffsetMax || RotateOffsety < -RotateOffsetMax)
        {
            
            //rotate cam to follow car if car is outside RotateOffsetMax range 
            float angle = Time.time * PlayerControllerScript.Rotate;// angle represente rotationspeed
            Vector3 positionCenterObject = Player.transform.position; // this is the object to be rotated around

            // stupid math (I looked this up)
            var x = positionCenterObject.x + Mathf.Cos(angle) * Offset.x;
            var z = positionCenterObject.z + Mathf.Sin(angle) * Offset.z;
            transform.position = new Vector3(x, transform.position.y, z);

            Debug.Log("Car is outside offset; cam will follow car");
        }
        
    }
}
