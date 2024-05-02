using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnim;

    private float speed = 15f;
    // Start is called before the first frame update
    void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetFloat("speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
