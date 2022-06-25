using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float moveForce;

    Rigidbody2D rb;
    WallDetector left_side;
    WallDetector right_side;
    FeetChecker feet;

    int dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        left_side = transform.Find("hands_left").gameObject.GetComponent<WallDetector>();
        right_side = transform.Find("hands_right").gameObject.GetComponent<WallDetector>();

        feet = transform.Find("feet").gameObject.GetComponent<FeetChecker>();

        dir = -1;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(dir * moveForce, 0, 0));

        if (feet.Grounded())
        { 
            if (left_side.WallFound())
            {
                //Debug.Log("FLIP");
                dir = 1;
            }
            if (right_side.WallFound())
            {
                //Debug.Log("FLIP");
                dir = -1;
            }
        }
    }
}
