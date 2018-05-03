using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*This projectile is based on the location of its target, 
     and will slow down gradually overtime, and eventually self destruct*/

public class Dart : ProjectileTemplate {

    [Header("Dart Properties:")]
    public Transform target; //End goal;
    public float rotationSpeed; //Speed at which it rotates towards its target;
    public float speedDecreaseAmount = 1; //Speed decreased over time;
        
    public override void Update() {
        base.Update();
        Tracking();
    }

    public override void SetParameters() {
        movementSpeed -= (movementSpeed / 10) * Time.deltaTime; //Decreases Speed over time;

        if(target == null)
        base.SetParameters(); //Behaves as a regular bullet if no target is assigned;
    }

    public void Tracking() { //Function that makes it so that the projectiles follow the target;
        if(target != null) {
            transform.up = Vector3.Lerp(transform.up ,target.position - transform.position, rotationSpeed*Time.deltaTime);
        }
    }
}
