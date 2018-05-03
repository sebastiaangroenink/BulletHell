using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 playerPos;
    public Vector3 asd;
    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;

        

       

    }

    void Update()
    {
        CheckMouse();
        CheckPlayerPos();


        transform.position = playerPos;
    }

    //Extra activation check to prevent errors
    void CheckMouse()
    {
        if (Input.GetButton("Fire1"))
        {
            MovePlayer(true);
        }
    }

    void CheckPlayerPos()
    {
    }

    //Moves player's character to user's mouse potion if Clicked.
    void MovePlayer(bool moveMe)
    {
        if (moveMe)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
            {
                playerPos = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z + 1);
            }
        }
        //checks if player doesn't go out of bounds.
        if (playerPos.x <= -20.8f)
        {
            playerPos.x = -20.8f;
        }
        if (playerPos.x >= 20.8f)
        {
            playerPos.x = 20.8f;
        }
        if (playerPos.y <= -11.5f)
        {
            playerPos.y = -11.5f;
        }
        if (playerPos.y >= 11.5f)
        {
            playerPos.y = 11.5f;
        }

    }
}
