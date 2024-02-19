using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Tutorial_Variables_Functions : MonoBehaviour
{
    // Start is called before the first frame update
    int myInt = 5;

    void Start()
    {
        myInt = 5;
    }

    // Update is called once per frame
    void Update()
    {
        myInt = MultiplyByTwo(myInt);
        Debug.Log(myInt);
    }

    int MultiplyByTwo(int num)
    {
        int result = num * 2;
        return result;
    }
}
