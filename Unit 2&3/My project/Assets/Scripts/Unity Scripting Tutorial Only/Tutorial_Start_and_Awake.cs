using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Start_and_Awake : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        //Used to initialize references between scripts and to initialize variables and other settings before enabling script component.
        //Executed even if script component isn't enabled
        //EX: assign ammo to enemy
        Debug.Log("Awake");
    }

    void Start()
    {
        //Used to execute part of initalization code once script is executed
        //Script needs to be executed, will run aftewr awake
        //EX: Give enemy ability to shoot
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
