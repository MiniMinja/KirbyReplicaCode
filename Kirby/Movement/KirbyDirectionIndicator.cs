using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyDirectionIndicator : MonoBehaviour
{
    KirbyMovementController kirby_move_script;

    // Start is called before the first frame update
    void Start()
    {
        kirby_move_script = GetComponent<KirbyMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(kirby_move_script.CurrentDirection() * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
}
