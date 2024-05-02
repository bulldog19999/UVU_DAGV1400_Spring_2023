using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemySpawns;
    [SerializeField] private GameObject zombiePrefab;
    private GameManager gameManager;

    private int spawnChance;
    private float spawnDelay = 0.8f;
    private float spawnInterval = 2.2f;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("EnableSpawn", spawnDelay, spawnInterval);
    }

    private void EnableSpawn()
    {
        if(!gameManager.gameOver)
        {
            for (int i = 0; i < enemySpawns.Length; i++)
            {
                spawnChance = Random.Range(1, 3);
                if (spawnChance == 2)
                {
                    Debug.Log("Spawn");
                    SpawnZombie(enemySpawns[i].transform.position);
                }
            }
        }  
    }

    private void SpawnZombie(Vector3 spawnPosition)
    {
        Instantiate(zombiePrefab, spawnPosition, zombiePrefab.transform.rotation);
    }
}
