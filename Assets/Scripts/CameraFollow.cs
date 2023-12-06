using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //Holds a reference to our vehicle
    public Vector3 offset; // Distance between camera and vehicle
    public float smoothSpeed = 0.1f;
    public bool isThirdPersonCam = false;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + offset;

    }

    private void LateUpdate()
    {
        //MoveCameraWithLerp
        Vector3 expectedPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, expectedPosition, smoothSpeed);

        transform.position = smoothPosition;

        if (isThirdPersonCam ) {
            
            transform.LookAt(player);
        }

        //transform.LookAt(player);
    }

    //private void MoveCameraWithoutLerp() //Move camera position without the smoothening values
    //{
        //Vector3 expectedPosition = player.position + offset;

        //transform.position = expectedPosition;
    //}



}
