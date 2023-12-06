using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    public float speed = 2.0f;

    public Rigidbody playerRb;
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    // Start is called before the first frame update
    void Start()
    {
        //thirdPersonCam = true;
        //firstPersonCam = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle forward
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward * Time.deltaTime * 20);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        if (Input.GetKeyDown(KeyCode.F))
        {
            firstPersonCam.enabled = true;
            thirdPersonCam.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.C)) 
        {
            thirdPersonCam.enabled= true;
            firstPersonCam.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity += moveDirection.normalized * speed;
    }
}
