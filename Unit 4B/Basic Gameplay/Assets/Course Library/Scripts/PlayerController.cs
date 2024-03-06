using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float rangeLimit;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        speed = 20f;
        rangeLimit = 20f;

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
        //Limit player movement, although I think I'd rather have an invisible wall than code
        if(transform.position.x < -rangeLimit)
        {
            transform.position = new Vector3(-rangeLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rangeLimit)
        {
            transform.position = new Vector3(rangeLimit, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Launch Projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }
}
