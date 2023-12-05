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
    // Start is called before the first frame update
    void Start()
    {
        
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

    }

    private void FixedUpdate()
    {
        playerRb.velocity += moveDirection.normalized * speed;
    }
}
