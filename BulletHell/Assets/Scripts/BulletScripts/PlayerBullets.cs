using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{

    public float damage;
    public float speed = 1.0f;
    public float safetyDecay = 5.0f;

    public GameObject player;
    public GameObject hitParticle;

    private void Awake()
    {
        player = GameObject.Find("Player_character");
    }
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        safetyDecay -= 1 * Time.deltaTime;

        if (safetyDecay < 0)
        {
            Destroy(transform.gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.tag == "Boss")
        {
            collision.transform.GetComponent<BossTemplate>().health -= damage;
            Instantiate(hitParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z - 10), Quaternion.identity);

            if (player != null)
            {
                player.GetComponent<PlayerController>().bulletsOnScreen--;
            }

            Destroy(transform.gameObject);

        }
        if (collision.transform.gameObject.tag == "Wall")
        {
            Destroy(transform.gameObject);

            if (player != null)
            {
                player.GetComponent<PlayerController>().bulletsOnScreen--;
            }
        }
    }
}
