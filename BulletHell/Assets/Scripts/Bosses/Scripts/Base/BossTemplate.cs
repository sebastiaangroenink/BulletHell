using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*This script is the base template for enemy variables and behaviour*/

public class BossTemplate : MonoBehaviour {

    [Header("Statistics:")]
    public float health = 1000;
    public float attackInterval = 0.5f; //Used for projectile instantiation;
    public float moveSpeed = 1.5f;

    [Header("Trivial Info:")]
    public Vector3 starterPosition; //Stored initial position saved for movement purposes;

    [Header("Offense Settings:")]
    public List<GameObject> projectiles; //Different types of projectile;

    #region Private Variables
    private float attackTimer = 0.5f; //Actual timer;
    protected bool cooledDown;
    #endregion

    public virtual void Update() {
        CoolDown(); //Decreasing timer;
        BaseAttack();
    }

    //Cooldown check for next initialization of attacking
    public virtual bool CoolDown() {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0) { //Checks if the attack timer hits 0;
            attackTimer = attackInterval; //Resets the timer;
            return true;
        }
        else
            return false; //If timer is not met with the conditions, no action will be performed;
    }


    public virtual void BaseAttack() {
        cooledDown = CoolDown();

    }
}
