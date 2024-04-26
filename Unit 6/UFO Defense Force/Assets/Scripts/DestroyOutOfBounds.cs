using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private ScoreManager scoreManager;

    public int penalty = 25;

    private float zLimit = 30f;


    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //For projectiles
        if(transform.position.z > zLimit)
        {
            Destroy(gameObject);
        }
        //For enemies
        if (transform.position.z < -zLimit)
        {
            Destroy(gameObject);

            if(gameObject.CompareTag("Enemy")) //if the enemy leaves thew bounds, give a penalty instead of a game over
            {
                scoreManager.DecreaseScore(penalty);
            }
        }
    }
}
