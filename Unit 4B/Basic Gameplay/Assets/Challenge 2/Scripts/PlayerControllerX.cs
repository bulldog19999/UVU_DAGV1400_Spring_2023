using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float spawnTimer = 100.0f;
    private bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn == true)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawn = false;
            countDown();

        }
    }

    void countDown()
    {
        while(canSpawn == false)
        {
            if (spawnTimer > 0.0f)
            {
                spawnTimer -= Time.deltaTime;
            }
            if (spawnTimer <= 0.0f)
            {
                spawnTimer = 100.0f;
                canSpawn = true;
            }
        }
    }

}
