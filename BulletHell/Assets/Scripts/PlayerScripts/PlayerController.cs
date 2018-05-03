using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player postition.
    public Vector3 playerPos;
    //main camera.
    public Camera cam;

    //different bullet types.
    public GameObject[] bulletTypes = new GameObject[5];

    //bullet type behaviour.
    public enum BulletType { One, Two, Three, Four, Five };
    public BulletType bulletType;


    //bullet type variables.
    public int maxBullets;
    public int volleyCount;
    public int bulletSpeed;
    public int bulletDamage;
    public float bulletAngle;
    public int baseAngle;
    public float bulletCooldown = 3.0f;

    public int bulletsOnScreen;

    //temp var
    public float decayTimer;

    private void Awake()
    {
        cam = Camera.main;       
    }

    void Update()
    {
        CheckMouse();
        Shoot();

        transform.position = playerPos;

        bulletCooldown -= 1 * Time.deltaTime;
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

    //Allows Player to shoot bullets.
    void Shoot()
    { 
        switch (bulletType)
        {
            case BulletType.One:
                maxBullets = 20;
                volleyCount = 5;
                bulletSpeed = 18;
                bulletDamage = 1;
                decayTimer = 3.0f;
                bulletAngle = 22.5f;
                baseAngle = -45;

                if(bulletsOnScreen < maxBullets-volleyCount && bulletCooldown <0)
                {
                    for(int i =0; i<volleyCount; i++)
                    {
                        GameObject bulletInstance;
                        bulletInstance = Instantiate(bulletTypes[0], transform.position,new Quaternion(+baseAngle + (bulletAngle * i), 180,0,0)) as GameObject;
                        bulletInstance.GetComponent<PlayerBullets>().damage = bulletDamage;
                        bulletInstance.GetComponent<PlayerBullets>().speed = bulletSpeed;
                        bulletInstance.GetComponent<PlayerBullets>().decay = decayTimer;
                        bulletsOnScreen++;
                    }
                    bulletCooldown = 0.4f;
                }



                break;

            case BulletType.Two:





                break;

            case BulletType.Three:





                break;

            case BulletType.Four:





                break;

            case BulletType.Five:





                break;
        }

    }
}
