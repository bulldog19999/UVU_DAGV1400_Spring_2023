using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private Animator playerAnim;

    public float verticalInput;
    public float horizontalInput;
    public float speed = 20.0f;
    public float turnSpeed = 10.0f;

    private float xLimit = 35.0f;
    private float zLowerLimit = -140.0f;
    private float zUpperLimit = 115.0f;
    private bool gameOver = false;
    private bool isSprinting = false;
    private bool isJumping = false;

    //private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            playerAnim.SetFloat("Forward", verticalInput);

            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

            if (transform.position.x > xLimit)
            {
                transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -xLimit)
            {
                transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
            }

            //If height changes and the player is not jumping, assume bug and this is the check to fix it
            if (transform.position.y > 0.89f && !isJumping)
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

            if(Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
            {
                StartCoroutine("sprintCoroutine");
                isSprinting = true;
            }

            if(Input.GetKeyUp(KeyCode.LeftShift) && isSprinting)
            {
                StopCoroutine("lastCoroutine");
                Debug.Log("Sprint Cancelled");
                isSprinting = false;
                speed /= 1.5f;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                spawnProjectile();
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You Lose");
            gameOver = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Win");
            gameOver = true;
        }
    }
    
    void spawnProjectile()
    {        
        Debug.Log("Shooten time");
        Instantiate(projectile, transform.position + new Vector3(0, 0, 4), transform.rotation);
    }
    

    IEnumerator sprintCoroutine()
    {
        //Need to find a way to stop/interupt this method. Not sure if the if statement is good enough
        speed *= 1.5f;
        yield return new WaitForSeconds(3.5f);
        
        //return speed to normal if not cancelled
        if(isSprinting)
        {
            speed /= 1.5f;
            isSprinting = false;
        }
        
    }
}
