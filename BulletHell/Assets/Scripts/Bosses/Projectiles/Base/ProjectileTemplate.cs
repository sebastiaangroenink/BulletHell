using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   /*Base behaviour of projectiles based on the forward and speed*/

public class ProjectileTemplate : MonoBehaviour {

    [Header("Velocity & Direction Settings:")]
    public float forwardAxis = 0;
    public float movementSpeed = 1.5f;
    public Vector3 rotation;

    public virtual void Awake() { //Sets some base variables for possible modification options;
        rotation.z = forwardAxis;
    }

    public virtual void SetParameters() {
        transform.eulerAngles = rotation; //Sets the Z axis based on the forward given;
    }

    public virtual void Update() {
        BaseMovement(); //Used to make projectiles move constantly;
        SetParameters(); //Makes some values be constant;
    }

    public virtual void BaseMovement() {
        transform.position += transform.up * Time.deltaTime * movementSpeed; //Forward movement
    }
}
