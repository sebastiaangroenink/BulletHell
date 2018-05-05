using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{

    private GameObject player;
    public GameObject explosionPrefab;

    private float clearTimer = 5.0f;

    private bool spawned = false;
    private bool countDown = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (countDown)
        {
            clearTimer -= Time.deltaTime;
        }


        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 20);
        }

        else if (!spawned)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (clearTimer < 0)
            {
                Destroy(explosionPrefab);
            }

            spawned = true;
            countDown = true;
        }
    }
}
