using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchBehavior : MonoBehaviour
{
    bool crouching;

    bool groundedOnceAfterCrouch;

    float collider_width;
    float collider_height;
    float sprite_width, sprite_height;
    BoxCollider2D kirby_collider;
    KirbySpriteBehavior kirby_sprite;

    KirbyMovementController kirby_move_script;
    
    FeetChecker feet;

    // Start is called before the first frame update
    void Start()
    {
        kirby_collider = GetComponent<BoxCollider2D>();
        kirby_sprite = GetComponent<KirbySpriteBehavior>();
        collider_width = kirby_collider.size.x;
        collider_height = kirby_collider.size.y;

        kirby_move_script = GetComponent<KirbyMovementController>();

        feet = transform.Find("feet").GetComponent<FeetChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (feet.Grounded())
        {
            if (!kirby_move_script.IsFluttering()) { 
                if (Input.GetKeyDown("s"))
                {
                    kirby_collider.size = new Vector2(collider_width, collider_height / 2);
                    kirby_sprite.Crouch();
                    crouching = true;
                }
                if (Input.GetKeyUp("s"))
                {
                    kirby_collider.size = new Vector2(collider_width, collider_height);
                    kirby_sprite.Idle();
                    crouching = false;
                }
            }
        }
    }

    public bool Crouching()
    {
        return crouching;
    }
}
