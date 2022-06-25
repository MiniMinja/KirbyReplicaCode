using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetChecker : MonoBehaviour
{
    public float landTime;

    bool landing;
    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            StartCoroutine(Land());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            landing = false;
            isGrounded = false;
        }
    }

    IEnumerator Land()
    {
        landing = true;

        yield return new WaitForSeconds(landTime);
        
        isGrounded = true;
    }

    public bool Grounded()
    {
        return isGrounded;
    }
}
