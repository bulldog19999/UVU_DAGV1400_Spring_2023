using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float turnSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        turnSpeed = 45f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Moves car forward based on key press
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //Rotates car left and right (along y axis) based on key press
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

    }
}
