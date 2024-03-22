using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed = 20.0f;
    public float turnSpeed = 10.0f;

    private float xLimit = 35.0f;
    private float zLowerLimit = -140.0f;
    private float zUpperLimit = 115.0f;
    //private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        if(transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }

        //If height changes and the player is not jumping, assume bug and this is the check to fix it
        if (transform.position.y != 3.89f)
        {
            transform.position = new Vector3(transform.position.x, 3.89f, transform.position.z);
        }

        if (transform.position.z > zUpperLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpperLimit);
        }

        if (transform.position.z < zLowerLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerLimit);
        }

        //Prevent rotations on x and z axis, should only occur on y axis
        //Read up on the pain of quaternions and euler angles to manually change rotation
        /*
        if (transform.rotation.x != 0)
        {
            transform.rotation = new Vector3(0, transform.rotation.y, transform.position.z);
        }

        if (transform.rotation.z != 0)
        {
            transform.rotation = new Vector3(transform.position.x, transform.rotation.y, 0);
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Win");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You Lose");
        }

    }

}
