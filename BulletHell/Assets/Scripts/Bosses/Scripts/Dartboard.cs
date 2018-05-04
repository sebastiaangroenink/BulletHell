using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : BossTemplate {

    public Transform target;

    [Header("Big Dart Settings:")]
    public float bigdartTimerInterval = 20;

    [Header("Small Dart Settings:")]
    public float minVelocityDarts = 50;
    public float maxVelocityDarts = 70;

    [Header("Angle Settings:")]
    public float angleAdjustment = 15;

    #region Private Variables
    private float bigdartTimer = 20;
    private float nextAngle = 0;
    private bool canshootBigdart;
    #endregion

    public override void BaseAttack() {
        base.BaseAttack();

        if (cooledDown) {
            GameObject projectile = Instantiate(projectiles[0].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);    
            projectile.GetComponent<ProjectileTemplate>().forwardAxis = nextAngle;
            projectile.GetComponent<ProjectileTemplate>().movementSpeed = Random.Range(minVelocityDarts, maxVelocityDarts);
            nextAngle += angleAdjustment;
        }

        canshootBigdart = CanShootBigDart();

        if (canshootBigdart) {
            GameObject bigProjectile = Instantiate(projectiles[1].gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            bigProjectile.GetComponent<Dart>().forwardAxis = nextAngle;
            bigProjectile.GetComponent<Dart>().target = target;
            nextAngle += angleAdjustment;
        }
    }

    private bool CanShootBigDart() {
        bigdartTimer -= Time.deltaTime;

        if(bigdartTimer <= 0) 
        {
            bigdartTimer = bigdartTimerInterval;
            return true;
        }

        return false;
    }
}
