using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*This projectile is based on the location of its target, 
     and will slow down gradually overtime, and eventually self destruct*/

public class Dart : ProjectileTemplate {

    [Header("Behaviour:")]
    public Transform target;
    public float baseMovementSpeed = 2;
    public float rotationSpeed;
        
    public override void Update() {
        base.Update();
        Tracking();
    }

    public void Tracking() {
        if(target != null) {
            transform.up = target.position - transform.position;
        }
    }
}
