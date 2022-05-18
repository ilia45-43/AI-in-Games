using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    private GameObject player;
    private float damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                damage = player.GetComponent<AttackSystem>().damage;
                EnemyHealthSystem healthSystem = other.gameObject.GetComponent<EnemyHealthSystem>();
                healthSystem.TakeDamage(damage);
                Destroy(gameObject);
                return;
            }
            else
            {
                if (other.gameObject.tag != "Player")
                {
                    Destroy(gameObject);
                    return;
                }
            }
        }
        else
        {
            Destroy(gameObject, 0.10f);
            return;
        }
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 1f);
    }
}
