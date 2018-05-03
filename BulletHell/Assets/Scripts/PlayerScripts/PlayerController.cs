using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	void Update () {


        CheckMouse();
	}

    //Extra activation check to prevent errors
    void CheckMouse()
    {
        if (Input.GetButton("Fire1"))
        {
            MovePlayer(true);
        }
    }
    
    //Moves player's character to user's mouse potion if Clicked.
    void MovePlayer(bool moveMe)
    {
        if (moveMe)
        {
            transform.position = Input.mousePosition;
        }
    }
}
