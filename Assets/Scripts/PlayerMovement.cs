using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed, defaultSpeed = 20.0f;
    public float sprintSpeed = 40.0f;
    public float rotateSpeed = 40.0f;
    public Rigidbody playerRb;
    
    public Camera firstPersonCam;
    public Camera thirdPersonCam;
    public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        //Generic Methods use <> 
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SetSpeed();
        SwitchCamsUsingOneKey();

    }

    public void GetInput()
    {

        // Horizontal input
        horizontalInput = (Input.GetKey(KeyCode.A) ? -1f : 0f) + (Input.GetKey(KeyCode.D) ? 1f : 0f);

        // Vertical input
        verticalInput = (Input.GetKey(KeyCode.W) ? 1f : 0f) + (Input.GetKey(KeyCode.S) ? -1f : 0f);

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    horizontalInput = -1.0f;
        //}
        ////else
        ////horizontalInput = 0.0f;

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    horizontalInput = 1.0f;
        //}
        ////else
        //{
        //    //horizontalInput = 0.0f;
        //}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    verticalInput = 1.0f;
        //}
        ////else
        //{
        //    //verticalInput=0.0f;
        //}
        //if (Input.GetKeyDown(KeyCode.S)) 
        //{
        //    verticalInput=-1.0f;
        //}
        ////else
        //    //verticalInput = 0.0f;
    }

    private void FixedUpdate()
    {
        //MoveCarWithForceAndTorque();
        MoveCarWithPhysicsRotation();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player2"))
            other.GetComponent<Rigidbody>().isKinematic = false;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player2"))
            other.GetComponent<Rigidbody>().isKinematic = true;
    }


    private void MoveCarWithForceAndTorque()
    {
        if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            playerRb.AddForce(transform.forward * verticalInput * speed); //vertical Input is a number between 0 and 1 
        }

        if (horizontalInput > 0.01f || horizontalInput < -0.01f)
        {
            playerRb.AddTorque(transform.up * horizontalInput * speed);
        }
    }

    private void MoveCarWithPhysicsRotation()
    {
        //Vector3 moveDirection = new Vector2(horizontalInput, verticalInput); No rotation
        Vector3 moveDirection = transform.forward * verticalInput;
        playerRb.MovePosition(playerRb.position + moveDirection * speed * Time.fixedDeltaTime);

         if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            float turnSpeed = horizontalInput * rotateSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnSpeed, 0f);
            playerRb.MoveRotation(playerRb.rotation * turnRotation);
        }
       
    }

    public void SetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = sprintSpeed; //no  { if its only one line
        else
            speed = defaultSpeed;
    }

    private void SwitchCamsUsingOneKey()
    {
        if (Input.GetKeyDown(keyCode))
        {
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
            firstPersonCam.enabled = !firstPersonCam.enabled;
        }

    }

   


}
