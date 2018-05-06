using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpet : BossTemplate {

    [Header("Trumpet Settings:")]
    public float shotTargetEventLength = 3; //Basetime of targetted event;
    public float rotationSpeed = 4;
    public float baseVelocity = 10;


    [Header("Regular Attack Settings:")]
    public float minVelocity = 10;
    public float maxVelocity = 15;
    public int maxProjectiles = 20;
    public int burstAmount = 8;
    public float shotIntervalBase = 0.01f; //Time betwheen each bullet base;

    #region Private Variables
    private float shotInterval; //Time of target event;
    private float multiplier = 1;
    #endregion

    public override void Start() {
        base.Start();

        shotInterval = shotIntervalBase;
    }

    public override void Update() {
        base.Update();
        Rotation();
    }

    void Rotation() { //Always looks at its target;
        if (player != null)
        {
            Vector2 direction = GameObject.FindWithTag("Player").transform.position - transform.position;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion finalRot = Quaternion.AngleAxis(targetAngle, new Vector3(0, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(finalRot.eulerAngles.x, finalRot.eulerAngles.y, finalRot.eulerAngles.z - 90), rotationSpeed * Time.deltaTime);
        }
    }

    public override void BaseAttack() { //Inherited base attack function;
        base.BaseAttack();

        ActivateBurstFire();

        if (cooledDown) 
        {
            for (int i = 0; i < maxProjectiles; i++) {
                GameObject projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                projectile.GetComponent<ProjectileTemplate>().forwardAxis = 360 / maxProjectiles * (i * multiplier + Random.Range(10f, 15f));
                projectile.GetComponent<ProjectileTemplate>().movementSpeed = Random.Range(minVelocity, maxVelocity);
            }

        }
    }

    public void ActivateBurstFire() {
            shotInterval -= Time.deltaTime;

            if (shotInterval <= 0) {

                for (int i = 0; i < burstAmount; i++) 
                {

                        GameObject projectile = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
                        projectile.GetComponent<ProjectileTemplate>().forwardAxis = transform.eulerAngles.z + 90 - (22.5f * i);
                        projectile.GetComponent<ProjectileTemplate>().movementSpeed = baseVelocity + (2 * i);
            }

            shotInterval = shotIntervalBase;
             }
          }
       }
