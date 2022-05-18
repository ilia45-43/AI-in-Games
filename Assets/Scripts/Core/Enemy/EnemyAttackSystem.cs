using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    private Animator animator;
    PlayerHealthSystem playerHealthSystem;

    private void Start()
    {
        playerHealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Player")
            {
                animator.SetBool("attaking", true);
                StartCoroutine(AttackPlayer());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.tag == "Player")
            {
                StopAllCoroutines();
                animator.SetBool("attaking", false);
            }
        }
    }

    private IEnumerator AttackPlayer()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2f);

        while (true)
        {
            playerHealthSystem.TakeDamage(5);
            yield return waitForSeconds;
        }
    }
}
