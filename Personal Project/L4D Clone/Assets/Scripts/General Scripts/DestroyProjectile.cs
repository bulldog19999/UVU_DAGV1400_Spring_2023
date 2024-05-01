using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destroyProjectileOnTimerRoutine());
    }

    IEnumerator destroyProjectileOnTimerRoutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
