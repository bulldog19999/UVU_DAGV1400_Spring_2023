using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Making private variables for movement and force, using [SerializeField] to allow them to be edited in unity, like a public variable
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
        }   

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
        }
    }
}
