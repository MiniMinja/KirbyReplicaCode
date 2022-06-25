using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitboxScript : MonoBehaviour
{
    public string enemyTag;

    KirbyMovementController movement_script;

    // Start is called before the first frame update
    void Start()
    {
        movement_script = GetComponentInParent<KirbyMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == enemyTag)
        {
            Vector3 dir = new Vector3(movement_script.CurrentDirection(), 0.3f, 0);
            collision.GetComponentInChildren<CharacterDamageBehavior>().TakeDamage(dir);
        }
    }
}
