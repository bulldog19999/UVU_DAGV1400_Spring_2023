using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_ActiveObjects : MonoBehaviour
{
    //Declare a new Light object variable
    private Light myLight;
    
    // Start is called before the first frame update
    void Start()
    {
        //Initalize on script execution
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            //Set the opposite status when pressing L
            myLight.enabled = !myLight.enabled;
        }
    }
}
