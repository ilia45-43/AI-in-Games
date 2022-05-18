using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private GameObject player;
    private ScoreSystem scoreSystem;
    private PlayerHealthSystem healthSystem;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        scoreSystem = player.GetComponent<ScoreSystem>();
        healthSystem = player.GetComponent<PlayerHealthSystem>();
    }

    public void TakeDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            scoreSystem.AddScore();
            System.Random random = new System.Random();
            if (random.Next(1, 6) == 4)
            {
                GetComponentInChildren<ParticleSystem>().Play();
                healthSystem.Regen();
            }
            Kill();
        }
    }

    private void Kill()
    {
        animator.SetTrigger("died");
        Destroy(navMeshAgent);
        Destroy(GetComponent<CapsuleCollider>());
        Destroy(GetComponent<EnemyMovement>());
        Destroy(gameObject, 1f);
    }
}
