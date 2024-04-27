using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip clip;
    private SoundManager soundManager;
    
    public int sceneToLoad;

    void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);  //Loads a specified scene, can load either using an index or a name (string)
        Debug.Log("New Scene Loaded");
    }

    public void quitGame()
    {
        soundManager.playSound(clip);
        Application.Quit();
        Debug.Log("Successfully Exited");
    }
}
