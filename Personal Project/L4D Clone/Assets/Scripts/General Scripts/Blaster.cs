using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject projectile;

    public void spawnProjectile()
    {
        Debug.Log("Shooten time");
        Instantiate(projectile, transform.position + new Vector3(0, 0, 4), transform.rotation);
    }

}
