using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Coffee : MonoBehaviour
{
    float coffeeTemp = 85.0f;
    float hotLimitTemp = 70.0f;
    float coldLimitTemp = 40.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            TemperatureTest();
        }

        coffeeTemp -= Time.deltaTime * 5f;
    }

    void TemperatureTest()
    {
        if(coffeeTemp > hotLimitTemp) 
        {
            Debug.Log("Ouch");
        }
        else if(coffeeTemp < coldLimitTemp)
        {
            Debug.Log("Gross");
        }
        else
        {
            Debug.Log("Just Right");
        }
    }
}
