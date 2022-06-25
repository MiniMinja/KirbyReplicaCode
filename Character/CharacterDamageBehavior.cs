using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageBehavior : MonoBehaviour
{
    public float invulnerableTime;
    public float knockBackPower;
    public string opposingTag;

    bool invulnerable;

    BoxCollider2D this_collider;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this_collider = transform.parent.GetComponent<BoxCollider2D>();
        invulnerable = false;

        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == opposingTag)
        {
            Vector3 dir = (transform.position - collider.transform.position).normalized;
            TakeDamage(dir);
        }
    }

    public void TakeDamage(Vector3 knockBackDir)
    {
        if (!invulnerable)
        {
            //take knockback
            Knockback(knockBackDir);

            //make invulnerable
            StartCoroutine(BeInvulnerable());
        }
    }

    public IEnumerator BeInvulnerable()
    {
        invulnerable = true;

        yield return new WaitForSeconds(invulnerableTime);

        invulnerable = false;
    }

    public bool Invulnerable()
    {
        return invulnerable;
    }

    public void Knockback(Vector3 knockbackDir)
    {
        rb.AddForce(knockbackDir * knockBackPower, ForceMode2D.Impulse);
    }

    public void GetSucked(Vector3 pullDir)
    {

    }
}
