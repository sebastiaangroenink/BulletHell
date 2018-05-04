using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : BossTemplate {

    public bool baseAttackSwitch = false;

    public override void Update()
    {
        base.Update();

        Rotate();
    }

    public override void BaseAttack()
    {
        base.BaseAttack();

        if (cooledDown)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    GameObject bulletInstance = Instantiate(projectiles[0].gameObject, transform.position,Quaternion.identity);
                    bulletInstance.GetComponent<ProjectileTemplate>().movementSpeed = 10 + 1.5f * i;

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
}
