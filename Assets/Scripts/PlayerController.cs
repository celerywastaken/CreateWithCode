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
    public float rotateSpeed = 30.0f;
    public float defaultspeed = 2.0f;
    public float sprint = 4.0f;

    public Rigidbody playerRb;
    public Camera firstPersonCam;
    public Camera thirdPersonCam;

    

    public KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle forward / Variations
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward * Time.deltaTime * 20);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        MovePlayerWithRotate(transform,rotateSpeed, speed);
        SwitchCamsUsingOneKey();

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    firstPersonCam.enabled = true;
        //    thirdPersonCam.enabled = false;
        //}

        //if (Input.GetKeyDown(KeyCode.C)) 
        //{
        //    thirdPersonCam.enabled= true;
        //    firstPersonCam.enabled = false;
        //}
    }

    private void MovePlayerWithTranslate(Transform player, float speed = 10.0f)
    {
        player.Translate(player.forward * speed * verticalInput * Time.deltaTime);
        player.Translate(player.right * speed *horizontalInput * Time.deltaTime);
    }

    private void MovePlayerWithRotate(Transform player, float rotateSpeed = 15.0f, float speed = 10.0f)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprint;
        }
        else
        {
            speed = defaultspeed;
        }


        player.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        if (verticalInput > 0.01f || verticalInput < -0.01f)
        {
            player.Rotate(Vector3.up, rotateSpeed * horizontalInput * Time.deltaTime);
        }

       
    }

    private void SwitchCamsUsingOneKey()
    {
        if (Input.GetKeyDown(keyCode))
        {
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
            firstPersonCam.enabled = !firstPersonCam.enabled;
        }
       
    }


   

    //private void FixedUpdate()
    //{
    //    playerRb.velocity += moveDirection.normalized * speed;
    //}


}
