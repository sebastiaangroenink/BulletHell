using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*This projectile is based on the location of its target, 
     and will slow down gradually overtime, and eventually self destruct*/

public class HeatSeekingProjectile : ProjectileTemplate {

    [Header("Dart Properties:")]
    public Transform target; //End goal;
    public float baseTrackingTimer = 10; //Time offset that decides how long the bullet should track its target;
    public float minRotspeed = 5;
    public float maxRotspeed = 10;

    #region Private Variables
    private float rotationSpeed; //Speed at which it rotates towards its target;
    #endregion

    #region Private Variables
    private float trackingTimer; //Actual timer;
    #endregion

    public override void Update() {
        BaseMovement();

        if(target != null)
        Tracking();
    }

    public void Awake()
    {
        rotationSpeed = Random.Range(minRotspeed, maxRotspeed);
        trackingTimer = baseTrackingTimer; //Compares and sets the tracking timer;
    }

    public void Tracking() { //Function that makes it so that the projectiles follow the target;
        trackingTimer -= Time.deltaTime;

        if (trackingTimer <= 0)
            target = null;

        if (target != null)
        {
            Vector2 direction = target.position -transform.position;
            float targetAngle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(targetAngle, Vector3.back);
            Quaternion finalRot = Quaternion.AngleAxis(targetAngle, new Vector3(0, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(finalRot.eulerAngles.x, finalRot.eulerAngles.y, finalRot.eulerAngles.z -90),  rotationSpeed * Time.deltaTime);
        }
    }
}
