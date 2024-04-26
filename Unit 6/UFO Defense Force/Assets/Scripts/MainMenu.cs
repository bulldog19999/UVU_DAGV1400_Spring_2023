using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;
    
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);  //Loads a specified scene, can load either using an index or a name (string)
        Debug.Log("New Scene Loaded");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Successfully Exited");
    }
}
