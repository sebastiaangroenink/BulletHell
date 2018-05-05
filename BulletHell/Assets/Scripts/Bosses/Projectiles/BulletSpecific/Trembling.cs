using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*Scales up the y Axis between 2 values for unprecident collision*/

public class Trembling : ProjectileTemplate {

    [Header("Projectile Settings:")]
    public float maxScale;
    public float scalingSpeed;

    #region Private Variables
    private Vector3 startingScale;
    private float startingSizeY;
    #endregion

    public void Awake() {
        startingSizeY = transform.localScale.y;
        startingScale = transform.localScale; //Sets startingscale to current scale;
    }

    public override void Update () { //Overwritten function due to adding data;
        base.Update();

        transform.localScale = startingScale; //Sets localscale to the futurely adjusted startingscale;
        startingScale.y = Mathf.Lerp(startingScale.y, Mathf.PingPong(Time.time * scalingSpeed, maxScale) + startingSizeY, scalingSpeed * Time.deltaTime);
    }
}
