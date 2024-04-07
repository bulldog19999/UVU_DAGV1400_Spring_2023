using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zLimit = 22f; 

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > zLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -zLimit)
        {
            Destroy(gameObject);
        }
    }
}
