using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    bool foundWall;

    // Start is called before the first frame update
    void Start()
    {
        foundWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground") {
            foundWall = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            foundWall = false;
        }

    }

    public bool WallFound()
    {
        return foundWall;
    }
}
