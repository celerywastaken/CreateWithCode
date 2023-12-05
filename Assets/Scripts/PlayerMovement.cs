using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public Transform player;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moveforward(player, speed);
    }

    private void Moveforward(Transform something, float speed = 3.0f)
    {
        something.Translate(something.forward * speed * Time.deltaTime);
    }
}
