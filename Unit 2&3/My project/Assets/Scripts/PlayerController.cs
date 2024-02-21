/*TODO:
 * Add stamina system for sprint - ?
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Making private variables for movement, force, and rotation using [SerializeField] to allow them to be edited in unity, like a public variable
    //Removed Gravity Variable, Global gravity is preset to -9.81 in project settings, will componsate by editing mass of cube in hierarchy
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float rotationSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 300.0f;
    [SerializeField]
    private float runSpeedMult = 2.0f;

    //Instantiating Components, we will store the player objects CharacterController and RigidBody on start
    private CharacterController controller;
    private Rigidbody rb;

    private bool isJumping = false;
    private bool isSprinting = false;
    private bool isCrouched = false;

    void Start()
    {
        //Store Player's Controller and rigid body, anything else we want to use would be declared here
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Horizontal and vertical axis
        //By default for mouse and keyboard it's Mouse X and Mouse Y... up and down rotation (Y movement) occurs around the X axis,
        //Left and right rotation(Mouse X) occurs along the Y axis, added a negative to Mouse Y input to inverse controls: up = up, down = down
        float xRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float yRotation = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        transform.Rotate(yRotation, xRotation, 0);
        
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
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping && !isCrouched)
            {
                Jump();
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= runSpeedMult;
            isSprinting = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            moveSpeed /= runSpeedMult;
            isSprinting = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            moveSpeed /= runSpeedMult;
            controller.height /= 2f;
            isCrouched = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveSpeed *= runSpeedMult;
            controller.height *= 2f;
            isCrouched = false;
        }

    }

    private void Jump()
    {
        //By default, the object is not jumping.
        //Note, physics gets wonky and can cause the cube to unintentionally rotate
        rb.AddForce(Vector3.up * jumpForce);
        isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Debug.Log("Collison with floor");
            isJumping = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collison with enemy");
        }
    }
}
