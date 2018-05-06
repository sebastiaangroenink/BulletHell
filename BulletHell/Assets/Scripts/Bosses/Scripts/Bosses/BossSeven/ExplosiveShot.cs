using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveShot : ProjectileTemplate {

    public BossTemplate bossTemplate;

    public override void Start()
    {
        base.Start();

        bossTemplate = GameObject.Find("Boss_7").GetComponent<BossTemplate>();

        
    }

    public override void Update()
    {
        base.Update();

    }


    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if(other.tag == "BeeBossWall")
        {
            for (int i = 0; i < 23; i++)
            {
                GameObject bullet1 = Instantiate(bossTemplate.projectiles[1].gameObject, transform.position, Quaternion.identity);
                bullet1.GetComponent<ProjectileTemplate>().movementSpeed = 8f;
                bullet1.GetComponent<ProjectileTemplate>().forwardAxis = 0 + 16 * i;
            }
            Destroy(gameObject);
        }
    }
}
