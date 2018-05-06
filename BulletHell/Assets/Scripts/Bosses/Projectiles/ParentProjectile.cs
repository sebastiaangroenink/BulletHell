using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*During its lifetime, is able to instantiate projectiles itself*/

public class ParentProjectile : ProjectileTemplate {

    [Header("Parent Projectile Settings:")]
    public ProjectileTemplate projectiles;
    public int projectilefireAmount = 2;
    public float instanceTimerBase = 5;
    public float angleOffset;
    public int movementSpeedIncrease = 1;

    [Header("Generation Settings:")]
    public int maxGenerations = 1;

    [Header("Randomize AngleOffsetSettings:")]
    public bool randomizeOffset;

    #region Private Variables
    private int curGeneration;
    private float instanceTimer;
    #endregion

    public void Awake() {
        instanceTimer = instanceTimerBase;
    }

    public override void Update () {
        base.Update();

        Fire();
        Rotation();
	}

    void Rotation() { //Visual effect;
        transform.GetChild(0).transform.Rotate(0, 0, 100 * Time.deltaTime);
    }


    public override void SetParameters() {
        base.SetParameters();

        instanceTimer -= Time.deltaTime;
    }

    public void Fire() {
        bool cooldown = CoolDown();

        if (randomizeOffset)
            angleOffset = Random.Range(0, 360);

        if(cooldown && curGeneration < maxGenerations) {
            for(int i = 0; i < projectilefireAmount; i++) {
                GameObject projectile = Instantiate(projectiles.gameObject, transform.position, Quaternion.identity);
                projectile.GetComponent<ProjectileTemplate>().forwardAxis -= (angleOffset) * Mathf.PI;
                projectile.GetComponent<ProjectileTemplate>().movementSpeed = movementSpeed + movementSpeedIncrease;

                projectile = Instantiate(projectiles.gameObject, transform.position, Quaternion.identity);
                projectile.GetComponent<ProjectileTemplate>().forwardAxis += (angleOffset) * Mathf.PI;
                projectile.GetComponent<ProjectileTemplate>().movementSpeed = movementSpeed + movementSpeedIncrease;
            }
        }
    }

    public bool CoolDown() { //Cooldown for next shot;
        if(instanceTimer <= 0) {
            instanceTimer = instanceTimerBase;
            return true;
        }

        return false;
    }
}
