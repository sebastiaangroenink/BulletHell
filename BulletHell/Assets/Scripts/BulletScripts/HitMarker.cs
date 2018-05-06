using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour {

    public float decayTimer = 2.0f;

    void Update()
    {
        decayTimer -= Time.deltaTime;

        if(decayTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
