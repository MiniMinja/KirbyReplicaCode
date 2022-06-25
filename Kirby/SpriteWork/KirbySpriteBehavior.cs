using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbySpriteBehavior : MonoBehaviour
{
    public Sprite idle;
    public Sprite crouching;
    public Sprite fluttering;

    SpriteRenderer sp;

    KirbyMovementController kirby_move_script;

    bool stateChange;
    bool reset;
    string state;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        kirby_move_script = GetComponent<KirbyMovementController>();

        stateChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateChange)
        {
            if(state == "flutter")
            {
                sp.sprite = fluttering;
            }
            else if(state == "crouch")
            {
                sp.sprite = crouching;
            }
            else
            {
                sp.sprite = idle;
            }
            stateChange = false;
        }
    }

    public void Flutter()
    {
        state = "flutter";
        stateChange = true;
    }

    public void Crouch()
    {
        state = "crouch";
        stateChange = true;
    }

    public void Reset()
    {
        reset = true;
    }

    public void Idle()
    {
        state = "idle";
        stateChange = true;
    }
}
