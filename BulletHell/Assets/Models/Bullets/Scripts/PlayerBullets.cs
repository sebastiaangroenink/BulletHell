using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{

    public float damage;
    public float speed = 1.0f;
    public float decay;

    public GameObject player;


    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        //temp code
        decay -= 1 * Time.deltaTime;

        //temp code
        if (decay < 0)
        {
            Destroy(transform.gameObject);
            player.GetComponent<PlayerController>().bulletsOnScreen--;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Boss")
        {
            collision.transform.GetComponent<BossTemplate>().health -= damage;

        }
        Destroy(transform.gameObject);
        player.GetComponent<PlayerController>().bulletsOnScreen--;
    }
}
