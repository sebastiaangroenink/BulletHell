using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBoss : BossTemplate
{

    private bool firstShot;
    private bool firstBurst;

    private bool enableBurstOneTimer;

    public GameObject bossSevenWalls;

    private float burstTimer = 5f;

    private float phaseTwoSpawnTimer = 0f;
    private float phaseTwoSpawned;

    private int burstCount = 0;

    public override void Start()
    {
        base.Start();

        bossSevenWalls = GameObject.Find("Boss_7_Walls");
        bossSevenWalls.SetActive(true);
    }

    public override void Update()
    {
        base.Update();

        burstTimer -= Time.deltaTime;
        phaseTwoSpawnTimer -= Time.deltaTime;

        if (health >= 1750 &&burstTimer <0)
        {
            PhaseOne();
            burstTimer = 5f;
        }
        if(health <= 1750 && health >= 1000)
        {
            PhaseTwo();

        }

        if (burstTimer < 0 && burstCount < 4 &&health <=1000)
        {
            PhaseThree();
        }
    }

    void PhaseOne()
    {
            GameObject explosiveShot = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
            explosiveShot.GetComponent<ProjectileTemplate>().movementSpeed = 8.0f;
            explosiveShot.GetComponent<ProjectileTemplate>().forwardAxis = 180;
    }

    void PhaseTwo()
    {
        if(phaseTwoSpawnTimer < 0)
        {
            GameObject explosiveShotBurstLeft = Instantiate(projectiles[1].gameObject, transform.position, Quaternion.identity);
            explosiveShotBurstLeft.GetComponent<ProjectileTemplate>().movementSpeed = 8.0f;
            explosiveShotBurstLeft.GetComponent<ProjectileTemplate>().forwardAxis = 0 + 4 * phaseTwoSpawned;

            phaseTwoSpawnTimer = 0.01f;
            phaseTwoSpawned++;
        }
    }

    void PhaseThree()
    {
        GameObject explosiveShotBurstLeft = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
        explosiveShotBurstLeft.GetComponent<ProjectileTemplate>().movementSpeed = 8.0f;
        explosiveShotBurstLeft.GetComponent<ProjectileTemplate>().forwardAxis = 135 - 45 * burstCount;

        GameObject explosiveShotBurstRight = Instantiate(projectiles[0].gameObject, transform.position, Quaternion.identity);
        explosiveShotBurstRight.GetComponent<ProjectileTemplate>().movementSpeed = 8.0f;
        explosiveShotBurstRight.GetComponent<ProjectileTemplate>().forwardAxis = 225 + 45 * burstCount;

        burstCount++;


        if (burstCount >= 3)
        {
            burstCount = 0;
            firstBurst = true;
            burstTimer = 2.0f;
        }
    }
}
