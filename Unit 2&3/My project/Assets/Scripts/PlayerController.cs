using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Making private variables for movement and force, using [SerializeField] to allow them to be edited in unity, like a public variable
    //Removed Gravity Variable, Global gravity is preset to -9.81 in project settings, will componsate by editing mass of cube in hierarchy
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 300.0f;
    [SerializeField]
    private float runSpeedMult = 3.0f;

    private CharacterController controller;
    private Rigidbody rb;

    private Vector3 moveDirection;
    private bool isJumping = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //Three things hapenning:
            //Vector3.Forward -> (0,0,1) -> movement of 1 unit in Z axis (forward axis)
            //moveSpeed -> are exposed variable in the hierarchy we can modify for testing
            //Time.deltaTime -> Changes how translate works from per frame to per second
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }   

        if (Input.GetKey(KeyCode.S))
        {
            //Added a negative in front of Vector3.forward
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= runSpeedMult;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= runSpeedMult;
        }

    }

    private void Jump()
    {
        //By default, the object is not jumping.
        //Will be adding a conditional to only allow jumping when colliding with the floor
        //Need to add a collision check for the floor to represent a finished jump
        //Note, physics gets wonky and can cause the cube to unintentionally rotate

        if(!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Debug.Log("Collison with floor");
            isJumping = false;
        }
    }
}
