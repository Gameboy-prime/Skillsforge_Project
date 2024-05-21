using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageControl : MonoBehaviour
{
    public enum EnemyType {
        A,B, C,D
    }

    public EnemyType enemyType;

    [SerializeField] float health;
    [SerializeField] Animator anime;
    private float currentHealth;
    public float deathTime = 2.3f;

    [SerializeField] string deathAnimeString;
   
    private void Start()
    {
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -=damage;

        StartCoroutine(ReleaseEffect());

        if (currentHealth < 0)
        {
            Die();
        }

    }

    private void Die()
    {
        StartCoroutine(Dying());
    }

    

    IEnumerator Dying()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyMove>().enabled = false;
        anime.Play(deathAnimeString);
       

        EnemySpawner.EnemyDeadCount += 1;
        GameData.IncrementCoin();
        yield return new WaitForSeconds(deathTime);


        //Will release the ennemy object based on the type of the enemy
        if(enemyType== EnemyType.A)
        {
            FindObjectOfType<EnemySpawner>().enemyPool_l.Release(this.gameObject);
        }
        else if(enemyType== EnemyType.B)
        {
            FindObjectOfType<EnemySpawner>().enemyPool_2.Release(this.gameObject);
        }
        else if(enemyType== EnemyType.C)
        {
            FindObjectOfType<EnemySpawner>().enemyPool_3.Release(this.gameObject);
        }
        else if(enemyType== EnemyType.D)
        {
            FindObjectOfType<EnemySpawner>().enemyPool_4.Release(this.gameObject);
        }
        
    }

    IEnumerator ReleaseEffect()
    {
        //This portion is for the blood gush effect
        GameObject effect = FindObjectOfType<Effects>().bloodPool.Get();
        effect.transform.position = transform.position;
        effect.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(.3f);
        FindObjectOfType<Effects>().bloodPool.Release(effect);


    }
    
}
