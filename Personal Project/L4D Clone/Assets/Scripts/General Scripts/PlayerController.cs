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
    private Blaster blaster;

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
                //blaster.spawnProjectile();
                if(!isAttacking)
                {
                    isAttacking = true;
                    playerAnim.SetBool("isAttacking", true);
                    Invoke("StopAttack", 1.5f);
                    Debug.Log(isAttacking);
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("You Lose");
            //gameManager.gameOver = true;
            //gameManager.isDead = true;
            //playerAnim.GetComponent<Animator>().enabled = false;
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Win");
            gameManager.gameOver = true;
            playerAnim.GetComponent<Animator>().enabled = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 200f, 0), ForceMode.Impulse);
    }

    private void Attack()
    {
        isAttacking = true;
        playerAnim.SetBool("isAttacking", true);
        Invoke("StopAttack", 1.5f);
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
