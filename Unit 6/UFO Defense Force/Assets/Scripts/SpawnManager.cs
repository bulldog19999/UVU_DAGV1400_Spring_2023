using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;
    public GameManager gameManager;
    public bool gameOver;

    private float xLimit = 20f;
    private float delay = 2f;
    private float interval = 3f;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //Reference GameManager and Gamemanager script
        InvokeRepeating("powerupSpawn", delay, interval * 1.5f);                  //Spawn powerups on an increased interval than enemies
        InvokeRepeating("EnemySpawner", delay, interval);                         //spawn enemies using a delay and an interval
    }

    // Update is called once per frame
    void Update()
    {
    }

    void EnemySpawner()
    {
        //Spawn if game is not over
        if(!gameManager.isGameOver)
        {
            for (int i = 0; i < 2; i++)
            {
                index = Random.Range(0, 3);
                Instantiate(enemyPrefabs[index], new Vector3(Random.Range(-xLimit, xLimit), .8f, 20), enemyPrefabs[index].transform.rotation);
            }
        }
        
    }

    void powerupSpawn()
    {
        if (gameManager.isGameOver == false)
            Instantiate(powerupPrefab, new Vector3(Random.Range(-xLimit, xLimit), .8f, 20), powerupPrefab.transform.rotation);
    }
}
