using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 5, -7);
    
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after update -> Vehicle moves than camera moves
    void LateUpdate()
    {
        //Set the position of the camera to that of the player plus an offset vector so we are not inside the player
        transform.position = player.transform.position + offset;
    }
}
