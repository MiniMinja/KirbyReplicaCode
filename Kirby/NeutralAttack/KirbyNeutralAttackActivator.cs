using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyAttackActivator : MonoBehaviour
{
    public GameObject airblast_obj;

    KirbyAttackBehavior attack_script;

    GameObject slideAttack;
    GameObject suckClose, suckFar;

    // Start is called before the first frame update
    void Start()
    {
        slideAttack = transform.Find("SlideHitbox").gameObject;
        slideAttack.SetActive(true);

        attack_script = GetComponentInParent<KirbyAttackBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack_script.Sliding())
        {
            slideAttack.SetActive(true);
        }
        else
        {
            slideAttack.SetActive(false);
        }

        if (attack_script.AirBlast())
        {
            AirBlast();
        }
    }

    public void AirBlast()
    {
        GameObject projectile = Instantiate(airblast_obj);
        projectile.transform.position = transform.position;

        AirBlastScript airblast_script = projectile.GetComponent<AirBlastScript>();
        airblast_script.Blast(attack_script.CurrentDirection());
    }
}
