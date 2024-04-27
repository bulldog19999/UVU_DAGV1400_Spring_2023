using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip shootingSound;
    public AudioClip startSound;
    private AudioSource playerAudio;
    [SerializeField] private GameObject projectilePrefab;

    public float horizontalInput;
    public float speed;

    private int movementLimit = 22;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(startSound, 0.5f);  //Easier to play audio here than to deal with the main menu.
    }


    // Update is called once per frame
    void Update()
    {
        //initializes use of the horizontal axis to allow player movement when pressing a and d keys
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        //Set movement limits of x axis
        if(transform.position.x > movementLimit)
        {
            transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -movementLimit)
        {
            transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
            playerAudio.PlayOneShot(shootingSound, 1.0f);
        }

    }

    void shoot()
    {
        Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, 2), projectilePrefab.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Increase speed when colliding with a powerup
        if(other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            increaseSpeed();
        }
    }

    private void increaseSpeed()
    {
        StartCoroutine("powerupDuration");  //Begins the countdown to return speed to normal
        speed *= 1.5f;
    }

    IEnumerator powerupDuration()
    {
        yield return new WaitForSeconds(3);
        speed /= 1.5f;
    }

}
