using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyMovementController : MonoBehaviour
{
    public float regularDrag;
    public float flutterDrag;

    public float floatForce;
    public float jumpForce;
    public float moveForce;

    Rigidbody2D rb;
    FeetChecker feet_script;

    CrouchBehavior crouch_script;
    KirbySpriteBehavior kirby_sprite_script;

    bool jump;
    bool flutter;
    bool fluttering;
    bool exitFlutter;

    // 1 - right
    //-1 - left
    int dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        feet_script = transform.Find("feet").gameObject.GetComponent<FeetChecker>();

        crouch_script = GetComponent<CrouchBehavior>();
        kirby_sprite_script = GetComponent<KirbySpriteBehavior>();

        dir = 1;
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            dir = -1;
        }
        else if (Input.GetAxisRaw ("Horizontal") > 0)
        {
            dir = 1;
        }
        
        if (Input.GetKeyDown("w"))
        {
            if (feet_script.Grounded())
            {
                Jump();
            }
            else
            {
                Flutter();
            }
        }
        if (Input.GetKeyUp("w"))
        {
            flutter = false;
        }

        if (Input.GetKeyDown(KeyCode.Comma) && fluttering)
        {
            LoseFlutter();
            ExitFlutter();
        }
    }

    void FixedUpdate()
    {
        if (!crouch_script.Crouching())
        {
            rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * moveForce, 0, 0));

            
            if (jump)
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
                jump = false;
            }

            if(flutter)
            {
                rb.AddForce(new Vector3(0, floatForce, 0), ForceMode2D.Impulse);
            }
        }

    }

    public void Jump()
    {
        jump = true;
    }

    public void Flutter()
    {
        flutter = true;
        fluttering = true;
        rb.drag = flutterDrag;
        kirby_sprite_script.Flutter();
    }

    public void LoseFlutter()
    {
        flutter = false;
        fluttering = false;
        rb.drag = regularDrag;
        kirby_sprite_script.Idle();
    }

    public bool IsFluttering()
    {
        return fluttering;
    }

    public void ExitFlutter()
    {
        exitFlutter = true;
    }

    public void FullyExitFlutter()
    {
        exitFlutter = false;
    }

    public bool ExitingFlutter()
    {
        return exitFlutter;
    }

    public int CurrentDirection()
    {
        return dir;
    }

    public bool Grounded()
    {
        return feet_script.Grounded();
    }
}
