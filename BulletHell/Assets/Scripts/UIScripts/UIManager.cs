using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*Everything UI related*/

public class UIManager : MonoBehaviour {

    public static UIManager uimanager;

    [Header("Canvas Settings:")]
    public GameObject canvas;

    public void Awake() {
        InitializeHandler();
    }

    void InitializeHandler() {
        if (uimanager == null)
            uimanager = this;
        else
            Destroy(gameObject);
    }  
}
