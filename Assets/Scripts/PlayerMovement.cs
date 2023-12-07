using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed, defaultSpeed = 20.0f;
    public float sprintSpeed = 40.0f;
    public float rotateSpeed = 40.0f;

    public Rigidbody playerRb;

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


    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //MoveCarWithForceAndTorque();
        MoveCarWithPhysicsRotation();
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
}
