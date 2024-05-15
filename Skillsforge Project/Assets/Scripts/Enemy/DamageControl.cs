using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageControl : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Animator anime;
    private float currentHealth;

    [SerializeField] string deathAnimeString;


    private void Start()
    {
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -=damage;

        if(currentHealth < 0)
        {
            Die();
        }

    }

    private void Die()
    {
        anime.Play(deathAnimeString);
        GetComponent<NavMeshAgent>().enabled= false;
        GetComponent<EnemyMove>().enabled= false;
    }
}
