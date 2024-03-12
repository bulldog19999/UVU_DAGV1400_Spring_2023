using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 10;
    public float gravityModifier;

    public bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Adding , ForceMode.Impulse to add force instantainiously instead of over time
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
