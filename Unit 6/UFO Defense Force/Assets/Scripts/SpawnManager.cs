using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;

    private float xLimit = 20f;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("powerupSpawn", 1.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            EnemySpawner();
        }
    }

    void EnemySpawner()
    {
        for(int i = 0; i < 2; i++)
        {
            index = Random.Range(0, 3);
            Instantiate(enemyPrefabs[index], new Vector3(Random.Range(-xLimit, xLimit),.8f,20), enemyPrefabs[index].transform.rotation);
        }
    }

    void powerupSpawn()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-xLimit, xLimit), .8f, 20), powerupPrefab.transform.rotation);
    }
}
