using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    private GameObject gameOverText;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            EndGame();
        }
        else
        {
            gameOverText.gameObject.SetActive(false);
        }
        
    }

    public void EndGame()
    {
        /*
         * Activate Game over text
         * Set time to 0
         */
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f; //freeze time...
    }
}
