using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed, defaultSpeed = 20.0f;
    public float rotateSpeed = 40.0f;
    public float sprintSpeed = 40.0f;
    public float horizontalInput, verticalInput;
    public Rigidbody player2Rb;
    public Camera firstPersonCam2;
    public Camera thirdPersonCam2;
    public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        player2Rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SetSpeed();
        SwitchCamsUsingOneKey();
    }

    private void FixedUpdate()
    {
        MoveCarWithPhysicsRotation();
    }
    public void GetInput()
    {
        // Horizontal input
        horizontalInput = (Input.GetKey(KeyCode.LeftArrow) ? -1f : 0f) + (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f);

        // Vertical input
        verticalInput = (Input.GetKey(KeyCode.UpArrow) ? 1f : 0f) + (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);
    }

    private void MoveCarWithPhysicsRotation()
    {
        //Vector3 moveDirection = new Vector2(horizontalInput, verticalInput); No rotation
        Vector3 moveDirection = transform.forward * verticalInput;
        player2Rb.MovePosition(player2Rb.position + moveDirection * speed * Time.fixedDeltaTime);

        if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            float turnSpeed = horizontalInput * rotateSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnSpeed, 0f);
            player2Rb.MoveRotation(player2Rb.rotation * turnRotation);
        }

    }
    public void SetSpeed()
    {
        if (Input.GetKey(KeyCode.RightShift))
            speed = sprintSpeed; //no  { if its only one line
        else
            speed = defaultSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void SwitchCamsUsingOneKey()
    {
        if (Input.GetKeyDown(keyCode))
        {
            thirdPersonCam2.enabled = !thirdPersonCam2.enabled;
            firstPersonCam2.enabled = !firstPersonCam2.enabled;
        }

    }

}

