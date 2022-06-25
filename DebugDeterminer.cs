using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDeterminer : MonoBehaviour
{
    public GameObject kirby;
    public bool showVelocity;

    public GameObject enemy;
    public bool showVelocityOfEnemy;

    Rigidbody2D kirby_rb;

    Rigidbody2D enemy_rb;

    private void Start()
    {
        kirby_rb = kirby.GetComponent<Rigidbody2D>();
        enemy_rb = enemy.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (showVelocity)
        {
            Debug.DrawLine(kirby.transform.position, kirby.transform.position + (Vector3)kirby_rb.velocity);
        }

        if (showVelocityOfEnemy)
        {
            Debug.DrawLine(enemy.transform.position, enemy.transform.position + (Vector3)enemy_rb.velocity);
        }
    }

}
