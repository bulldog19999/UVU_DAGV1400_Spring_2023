using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ScoreManager scoreManager; //Store ref to store manager

    public int scoreToGive;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); //Initalize storemanager and reference scoremanager script
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected");
        scoreManager.IncreaseScore(scoreToGive); //Increase score    
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
