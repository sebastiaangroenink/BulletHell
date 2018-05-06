using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcano : BossTemplate {

    [Header("Vulcano Settings:")]
    public float rotationSpeed = 5;
    public int healthPhaseTwo = 1500;

    [Header("Vulcano Projectile Settings:")]
    public float bendForce = 40;
    public float spacing = 5;
    public float velocity = 10;
    public float bendVelocity = 20;
    public float bendProjTimerBase = 0.3f;


    #region Private Variables
    private float angleOffset = 0;
    private bool phaseTwo = false;
    private float bendProjTimer;
    #endregion

    public override void Update() {
        base.Update();

        bendProjTimer -= Time.deltaTime;
    }

    public override void Start() {
        base.Start();

        bendProjTimer = bendProjTimerBase;
    }

    public override void BaseAttack() {
        base.BaseAttack();

        bool canFireBendingProjectiles = BendingProjectileCooldown();

        if (health <= healthPhaseTwo)
            phaseTwo = true;

        if (cooledDown) {

                    GameObject projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                    projectile.GetComponent<ProjectileTemplate>().movementSpeed = velocity;
                    projectile.GetComponent<ProjectileTemplate>().forwardAxis = angleOffset + rotationSpeed;

                    projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                    projectile.GetComponent<ProjectileTemplate>().movementSpeed = velocity;
                    projectile.GetComponent<ProjectileTemplate>().forwardAxis = -angleOffset + rotationSpeed;

                    projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                    projectile.GetComponent<ProjectileTemplate>().movementSpeed = velocity;
                    projectile.GetComponent<ProjectileTemplate>().forwardAxis = -angleOffset + -rotationSpeed;

                    projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                    projectile.GetComponent<ProjectileTemplate>().movementSpeed = velocity;
                    projectile.GetComponent<ProjectileTemplate>().forwardAxis = +angleOffset + -rotationSpeed;


                    angleOffset += spacing;
            }

            if(phaseTwo && canFireBendingProjectiles) {
            GameObject projectile = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileTemplate>().movementSpeed = bendVelocity;
            projectile.GetComponent<ProjectileTemplate>().forwardAxis = rotationSpeed * Mathf.PI * angleOffset;
            projectile.GetComponent<Bending>().bendingAngle = bendForce;

            projectile = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileTemplate>().movementSpeed = bendVelocity;
            projectile.GetComponent<ProjectileTemplate>().forwardAxis = -rotationSpeed * Mathf.PI * angleOffset;
            projectile.GetComponent<Bending>().bendingAngle = -bendForce;
        }
        }

    public bool BendingProjectileCooldown() {
        if (bendProjTimer <= 0) {
            bendProjTimer = bendProjTimerBase;
            return true;
        }

        return false;
    }
    }
