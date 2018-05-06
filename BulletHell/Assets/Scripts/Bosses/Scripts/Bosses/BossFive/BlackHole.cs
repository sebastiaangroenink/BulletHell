using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : BossTemplate
{

    public GameObject specialAttack;
    public GameObject attackPhaseSwitch;

    public bool phaseTwo = false;
    public bool phaseThree = false;
    public bool burstOne = false;
    public bool burstTwo = false;

    public float phaseTwoTimer = 5.0f;
    public float phaseThreeTimer = 5.0f;

    public override void Start()
    {
        base.Start();

        specialAttack = GameObject.Find("Boss_5_Special_Attack_1");
        attackPhaseSwitch = GameObject.Find("attack_phase_switch");
        specialAttack.GetComponent<ParticleSystem>().Stop();
    }

    public override void Update()
    {
        base.Update();

        transform.Rotate(0, 0, -45 * Time.deltaTime);
        specialAttack.transform.Rotate(0, 33 * Time.deltaTime, 0);

        if (health > 2000)
        {
            if (cooledDown)
            {
                GameObject RandomBullets = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                RandomBullets.GetComponent<ProjectileTemplate>().movementSpeed = Random.Range(6, 10);
                RandomBullets.GetComponent<ProjectileTemplate>().forwardAxis = Random.Range(0, 360);
            }
        }

        if (health <= 2000 && !phaseTwo)
        {
            phaseTwoTimer -= Time.deltaTime;

            if (!burstOne)
            {
                for (int i = 0; i < 90; i++)
                {
                    GameObject CircleBurst = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
                    CircleBurst.GetComponent<ProjectileTemplate>().movementSpeed = 5f;
                    CircleBurst.GetComponent<ProjectileTemplate>().forwardAxis = 0 + 4 * i;
                }
                burstOne = true;
            }

            if (phaseTwoTimer < 0)
            {
                specialAttack.GetComponent<ParticleSystem>().Play();
                phaseTwo = true;
            }
        }

        if(health <=1000 && !phaseThree)
        {
            Destroy(attackPhaseSwitch.gameObject);

            if (!burstTwo)
            {
                for (int i = 0; i < 45; i++)
                {
                    GameObject CircleBurst = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
                    CircleBurst.GetComponent<ProjectileTemplate>().movementSpeed = 5f;
                    CircleBurst.GetComponent<ProjectileTemplate>().forwardAxis = 0 + 8 * i;
                }
                burstTwo = true;
            }
        }





        if (player == null)
        {
            specialAttack.GetComponent<ParticleSystem>().Stop();
        }

    }
}