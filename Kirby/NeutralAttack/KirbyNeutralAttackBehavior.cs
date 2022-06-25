using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyAttackBehavior : MonoBehaviour
{
    public float slideForce;
    public float slideCD;

    Rigidbody2D rb;

    CrouchBehavior crouch_script;
    KirbyMovementController movement_script;

    float slideTime;
    bool sliding;

    bool air_blast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        crouch_script = GetComponent<CrouchBehavior>();
        movement_script = GetComponent<KirbyMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crouch_script.Crouching())
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                if (Time.time > slideTime + slideCD) {
                    rb.AddForce(Vector3.right * slideForce * movement_script.CurrentDirection(), ForceMode2D.Impulse);
                    slideTime = Time.time;
                    sliding = true; 
                }
            }
        }
        if (Time.time > slideTime + slideCD)
        {
            sliding = false;
        }



        if (movement_script.ExitingFlutter())
        {
            movement_script.FullyExitFlutter();
            air_blast = true;
        }
    }

    public bool Sliding()
    {
        return sliding;
    }

    public int CurrentDirection()
    {
        return movement_script.CurrentDirection();
    }

    public bool AirBlast()
    {
        bool air_blast_before = air_blast;
        air_blast = false;
        return air_blast_before;
    }
}
