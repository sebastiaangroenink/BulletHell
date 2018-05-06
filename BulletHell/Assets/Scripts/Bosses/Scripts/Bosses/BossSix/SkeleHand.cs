using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*New boss that introduces projectile duplication with main bending projectiles*/

public class SkeleHand : BossTemplate {

    [Header("SkeleHand Settings:")]
    public int healthTillSecondPhase;
    public List<Transform> instancePoints; //Used for Instantiating objects;
    public float bendingOffset = 20;

    [Header("Random Settings:")]
    public bool randomizeBendingOffset = false;
    public float minBendingOffset = 10;
    public float maxBendingOffset = 20;

    [Header("Phase Two Settings:")]
    public float baseSpecialTimer = 4;

    #region Private Variables
    private bool secondPhase = false;
    private float specialTimer;
    #endregion

    public override void Start() {
        base.Start();

        specialTimer = baseSpecialTimer;
    }

    public override void Update() {
        base.Update();

        specialTimer -= Time.deltaTime;
    }

    public override void BaseAttack() {
        base.BaseAttack();

        if (health <= healthTillSecondPhase)
            secondPhase = true;

        if(cooledDown) {
            for(int i = 0; i < instancePoints.Count; i++) {
                GameObject projectile = Instantiate(projectiles[0].gameObject, instancePoints[i].position, Quaternion.identity);
                projectile.GetComponent<Bending>().movementSpeed = 10;
                projectile.GetComponent<Bending>().forwardAxis = 180;
                if(randomizeBendingOffset)
                projectile.GetComponent<Bending>().bendingAngle = Random.Range(minBendingOffset, maxBendingOffset);
            }
        }

        bool specialCooldown = SpecialCooldown();

        if(secondPhase && specialCooldown) {
            GameObject projectile = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileTemplate>().forwardAxis = 90;

            projectile = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileTemplate>().forwardAxis = 270;
        }
    }  
    
    bool SpecialCooldown() {
        if(specialTimer <= 0) {
            specialTimer = baseSpecialTimer;
            return true;
        }
        return false;
    } 
}
