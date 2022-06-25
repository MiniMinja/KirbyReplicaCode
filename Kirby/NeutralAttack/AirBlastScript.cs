using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlastScript : MonoBehaviour
{
    public string enemy_tag;
    public float initial_air_blast_speed;

    float blastSpeed;
    int dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Blast(int dir)
    {
        gameObject.SetActive(true);

        blastSpeed = initial_air_blast_speed;
        this.dir = dir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + blastSpeed * dir, transform.position.y);
        blastSpeed -= 0.01f;
        if(blastSpeed < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == enemy_tag)
        {
            Vector3 dmgDir = collision.transform.position - transform.position;
            dmgDir = new Vector3(dmgDir.x, dmgDir.y + 0.1f).normalized;
            CharacterDamageBehavior dmg_behavior = collision.GetComponentInChildren<CharacterDamageBehavior>();
            if (dmg_behavior == null) Debug.Log("Error?");
            else dmg_behavior.TakeDamage(dmgDir);
        }
    }
}
