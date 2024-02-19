using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Update_and_FixedUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Called every frame (time between frames can vary)
        //used for regular updates such as:
        //Moving non-physics objects
        //simple timers
        //Recieving Input

        //update interval times vary
        Debug.Log("Update time: " + Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //Called every physics step
        //consistent intervals
        //used for regular updates such as:
        //Adjusting physics (Rigidbody) objects / anmything that affects a rigid body

        Debug.Log("Fixed time: " + Time.deltaTime);
    }
}
