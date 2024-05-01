using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject winScreen;
    private GameObject loseScreen;

    public bool gameOver;
    public bool isDead;

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
            loseScreen.gameObject.SetActive(true);
        }

        if (gameOver && !isDead)
        {
            winScreen.gameObject.SetActive(true);
        }
    }
}
