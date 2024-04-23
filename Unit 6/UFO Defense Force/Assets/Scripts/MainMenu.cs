using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(sceneToLoad);  //Loads a specified scene, can load either using an index or a name (string)
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Successfully Exited");
    }
}
