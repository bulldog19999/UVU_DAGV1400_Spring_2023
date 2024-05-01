using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool isDead;

    private GameObject winScreen;
    private GameObject loseScreen;
    // Start is called before the first frame update
    void Awake()
    {
        gameOver = false;
        loseScreen = GameObject.Find("Game_Over_UI");
        winScreen = GameObject.Find("Victory_UI");

        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && isDead)
        {
            Debug.Log("Activate Game Over Screen");
            loseScreen.gameObject.SetActive(true);
        }

        if (gameOver && !isDead)
        {
            Debug.Log("Activate victory Screen");
            winScreen.gameObject.SetActive(true);
        }
    }
}
