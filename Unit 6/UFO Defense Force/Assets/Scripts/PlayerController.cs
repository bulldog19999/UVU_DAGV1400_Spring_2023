using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;

    private int movementLimit = 22;

    [SerializeField] private GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }

    }

    void shoot()
    {
        Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, 2), projectilePrefab.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Powered Up");
        }
    }

}
