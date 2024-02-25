using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    private float spinSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spinSpeed = 2000f;
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
