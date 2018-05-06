using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcano : BossTemplate {

    [Header("Vulcano Settings:")]
    public float rotationSpeed = 5;
    public int bulletAmount = 3;

    private float angleOffset = 0;

    public override void BaseAttack() {
        base.BaseAttack();

        if (cooledDown) {
            for (int i = 0; i < bulletAmount; i++) {
                GameObject projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                projectile.GetComponent<ProjectileTemplate>().forwardAxis = angleOffset + rotationSpeed;
                projectile.GetComponent<ProjectileTemplate>().forwardAxis = angleOffset + rotationSpeed;
            }
        }
    }
}
