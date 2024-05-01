using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private GameManager gameManager;
    private Animator playerAnim;
    private Rigidbody rb;
    private Blaster blaster;    //figuring out if i want to keep or not, blaster code is currently functional

    public float verticalInput;
    public float horizontalInput;
    public float speed = 20.0f;
    public float turnSpeed = 10.0f;
    public bool isAttacking = false;

    private float xLimit = 35.0f;
    private bool isSprinting = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        blaster = GameObject.Find("Blaster").GetComponent<Blaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver) {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            //This is used to help control animation state by connecting vertical movement with "Forward" parameter
            playerAnim.SetFloat("Forward", verticalInput);

            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

            //x limits keep the player from falling out of the world... although this won't work on different sized levels
            if (transform.position.x > xLimit)
            {
                transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -xLimit)
            {
                transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
            }

            if(Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
            {
                StartCoroutine("sprintCoroutine");
                isSprinting = true;
            }

            //This basically functions as (Sprint by holding shift), sprint is not a toggle due to personal preference
            if(Input.GetKeyUp(KeyCode.LeftShift) && isSprinting)
            {
                StopCoroutine("lastCoroutine");
                Debug.Log("Sprint Cancelled");
                isSprinting = false;
                speed /= 1.5f;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                //blaster.spawnProjectile();
                if(!isAttacking)
                {
                    StartCoroutine("Attack");
                }

            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(!isJumping)
                {
                    Jump();
                    isJumping = true;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Having the check for attacking prevents the melee character from getting killed right away
        //Attacking relies on the sword (paranted to the player) colliding with zombies
        if (collision.gameObject.CompareTag("Enemy") && !isAttacking)
        {
            gameManager.gameOver = true;
            gameManager.isDead = true;
            playerAnim.GetComponent<Animator>().enabled = false;
        }

        //prevents double jumps
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            gameManager.gameOver = true;
            playerAnim.GetComponent<Animator>().enabled = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 200f, 0), ForceMode.Impulse);
    }

    //Modifies isAttacking bool and plays animation. Also calls the helper function StopAttack() to reset variables to original values
    IEnumerator Attack()
    {
        isAttacking = true;
        playerAnim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1.5f);
        StopAttack();
    }

    private void StopAttack()
    {
        playerAnim.SetBool("isAttacking", false);
        isAttacking = false;
    }

    IEnumerator sprintCoroutine()
    {
        //Increases speed by half, speed is increased while player is holding down shift
        //if shift is released early, then speed is returned to normal
        
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
