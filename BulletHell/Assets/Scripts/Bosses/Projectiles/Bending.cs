using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bending : ProjectileTemplate {

    [Header("Bending Settings:")]
    public float bendingAngle = 10;
    public float bendTime = 3;

    #region Private Variables
    #endregion

    public override void Start() {
        base.Start();
    }

    public override void SetParameters () {
        base.SetParameters();

        bool canBend = CanBend();

        bendTime -= Time.deltaTime;

        if(canBend)
        rotation.z += bendingAngle * Time.deltaTime;
	}

    private bool CanBend() {
        if (bendTime <= 0)
            return false;
        else
            return true;
    }
}
