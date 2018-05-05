using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : BossTemplate {

    public bool baseAttackSwitch = false;
    public float circleBurst = 2.0f;
    int circeBurstCount = 0;
    float canBurst = 0;

    public override void Update()
    {
        base.Update();

        Rotate();
        SpecialBurstAttack();

        circleBurst -= Time.deltaTime;
    }

    public override void BaseAttack()
    {
        base.BaseAttack();

        if(health < 1500)
        {
            attackInterval = 1.0f;
        }

        if (cooledDown)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    GameObject bulletInstance = Instantiate(projectiles[0].gameObject, transform.position,Quaternion.identity);
                    bulletInstance.GetComponent<ProjectileTemplate>().movementSpeed = 6 + 2f * i;

                    if (baseAttackSwitch)
                        bulletInstance.GetComponent<ProjectileTemplate>().forwardAxis = 0 + 60 * j;
                    else
                        bulletInstance.GetComponent<ProjectileTemplate>().forwardAxis = 45 + 60 * j;
                }
            }
            if (baseAttackSwitch)
                baseAttackSwitch = false;
            else
                baseAttackSwitch = true;
        }
    }

    void Rotate()
    {
        transform.Rotate(0f, 0f, 100f * Time.deltaTime);
    }

    void SpecialBurstAttack()
    {
        if (health < 1500 && player !=null)
        {
            if (circleBurst < 0)
            {
                canBurst -= Time.deltaTime;

                if (circeBurstCount < 46 && canBurst <= 0)
                {
                    GameObject bulletInstanceLeft = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
                    bulletInstanceLeft.GetComponent<ProjectileTemplate>().movementSpeed = 15f;
                    bulletInstanceLeft.GetComponent<ProjectileTemplate>().forwardAxis = 0 + 8 * circeBurstCount;

                    GameObject bulletInstanceRight = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
                    bulletInstanceRight.GetComponent<ProjectileTemplate>().movementSpeed = 15f;
                    bulletInstanceRight.GetComponent<ProjectileTemplate>().forwardAxis = 4 - 8 * circeBurstCount;

                    canBurst = 0.02f;
                    circeBurstCount++;
                }

                if (circeBurstCount >= 46)
                {
                    circleBurst = 1;
                    canBurst = 0;
                    circeBurstCount = 0;
                }
            }
        }
    }
}
