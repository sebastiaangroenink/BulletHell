using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : BossTemplate
{

    public GameObject specialAttack;

    public bool phaseTwo = false;

    public override void Start()
    {
        base.Start();

        specialAttack = GameObject.Find("Boss_5_Special_Attack_1");
        specialAttack.GetComponent<ParticleSystem>().Stop();
    }

    public override void Update()
    {
        base.Update();

        transform.Rotate(0, 0, -45 * Time.deltaTime);
        specialAttack.transform.Rotate(0, 33 * Time.deltaTime, 0);

        if (health > 1500)
        {
            if (cooledDown)
            {
                GameObject RandomBullets = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                RandomBullets.GetComponent<ProjectileTemplate>().movementSpeed = Random.Range(6, 10);
                RandomBullets.GetComponent<ProjectileTemplate>().forwardAxis = Random.Range(0, 360);
            }
        }

        if (health < 1500 && !phaseTwo)
        {
            specialAttack.GetComponent<ParticleSystem>().Play();
            phaseTwo = true;
        }




        if (player == null)
        {
            specialAttack.GetComponent<ParticleSystem>().Stop();
        }

    }
}