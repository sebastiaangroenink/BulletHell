using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : BossTemplate {

    private float nextAngle = 0;

	public override void BaseAttack() {
        base.BaseAttack();

        if (cooledDown) {
            GameObject projectileObj = Instantiate(projectiles[0], gameObject.transform.position, Quaternion.identity);
            projectileObj.transform.SetParent(UIManager.uimanager.canvas.transform);
            ProjectileTemplate projectile = projectileObj.GetComponent<ProjectileTemplate>();
            projectile.forwardAxis = nextAngle;
            nextAngle += 5;
        }
    }
}
