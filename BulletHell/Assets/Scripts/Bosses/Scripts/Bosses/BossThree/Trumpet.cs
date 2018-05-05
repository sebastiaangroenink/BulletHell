using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpet : BossTemplate {

    [Header("Trumpet Settings:")]
    public float shotTargetEventLength = 3; //Basetime of targetted event;
    public float shotIntervalBase = 0.01f; //Time betwheen each bullet base;
    public bool isTargetted = false;
    public float rotationSpeed = 4;

    #region Private Variables
    private int amountShot = 0;
    private float shotTimer; //Time between each bullet when targetted;
    private float shotInterval; //Time of target event;
    private bool patternSwitch;
    #endregion

    public override void Start() {
        base.Start();

        shotInterval = shotIntervalBase;
        shotTimer = shotTargetEventLength;
    }

    public override void Update() {
        base.Update();
        Rotation();
    }

    void Rotation() { //Always looks at its target;
        Vector2 direction = GameObject.FindWithTag("Player").transform.position - transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(targetAngle, Vector3.back);
        Quaternion finalRot = Quaternion.AngleAxis(targetAngle, new Vector3(0, 0, 1));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(finalRot.eulerAngles.x, finalRot.eulerAngles.y, finalRot.eulerAngles.z - 90), rotationSpeed * Time.deltaTime);
    }

    public override void BaseAttack() { //Inherited base attack function;
        base.BaseAttack();

        if (cooledDown && isTargetted == false) {
            GameObject projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileTemplate>().forwardAxis = 180;
            projectile.GetComponent<ProjectileTemplate>().movementSpeed = 5;
        }

        if (isTargetted == true) {
            ActivateTargetedFire();


        }
    }

    public void ActivateTargetedFire() {
            shotTimer -= Time.deltaTime;
            shotInterval -= Time.deltaTime;

            if (shotTimer > 0) {
            if (shotInterval <= 0) {

     if (patternSwitch == true) {
                for (int i = 0; i < 8; i++) {


                        GameObject projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                        projectile.GetComponent<ProjectileTemplate>().forwardAxis = transform.eulerAngles.z + 90 - (22.5f * i);
                        projectile.GetComponent<ProjectileTemplate>().movementSpeed = 10;
                        shotInterval = shotIntervalBase;
                        patternSwitch = false;
                        break;
                    }

     }

            if (patternSwitch == false) {
                for (int i = 0; i < 4; i++) {

                        GameObject projectile = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
                        projectile.GetComponent<ProjectileTemplate>().forwardAxis = transform.eulerAngles.z + 90 - (11.25f * i);
                        projectile.GetComponent<ProjectileTemplate>().movementSpeed = 10;
                        shotInterval = shotIntervalBase;
                        patternSwitch = true;
                        break;
                      
                    }
                }
            }
        }
            else {
            shotTimer = shotTargetEventLength;
            isTargetted = false;
        }
    }
}
