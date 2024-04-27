using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ScoreManager scoreManager; //Store ref to store manager
    public GameManager gameManager;   //ref to game manager
    public SoundManager soundManager;
    private AudioSource enemySound;
    public AudioClip enemyExplosionSound;

    public int scoreToGive;

    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); //Initalize storemanager and reference scoremanager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

        enemySound = GetComponent<AudioSource>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Only destroy enemies when they collide with a projecile, prevents unintentional destruction from overlaps
        //Audio source is being destroyed 
        if (gameObject.CompareTag("Enemy") && (other.CompareTag("Projectile")))
        {
            scoreManager.IncreaseScore(scoreToGive); //Increase score    
            soundManager.playSound(enemyExplosionSound);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("Player")) //end game when enemy collides with player
        {
            Destroy(other.gameObject);
            soundManager.playSound(enemyExplosionSound);
            gameManager.isGameOver = true;
        }
    }
}
