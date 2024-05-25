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

    [SerializeField] int health;
    [SerializeField] Animator anime;
    private int currentHealth;
    public float deathTime = 2.3f;

    [SerializeField] string deathAnimeString;
    [SerializeField] string fightAnimeString;

    private EnemySpawner spawner;
    private CapsuleCollider collider;
    private NavMeshAgent agent;
    private EnemyMove move;
    private Effects effects;

    

    public int damageLevel = 10;
   
    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        collider= GetComponent<CapsuleCollider>();
        agent= GetComponent<NavMeshAgent>();
        effects= FindObjectOfType<Effects>();
        move= GetComponent<EnemyMove>();
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
        collider.enabled = false;
        agent.enabled = false;
        move.enabled = false;
        anime.Play(deathAnimeString);
       

        EnemySpawner.EnemyDeadCount += 1;
        GameData.IncrementCoin();
        yield return new WaitForSeconds(deathTime);


        //Will release the ennemy object based on the type of the enemy
        if(enemyType== EnemyType.A)
        {
            spawner.enemyPool_l.Release(this.gameObject);
        }
        else if(enemyType== EnemyType.B)
        {
            spawner.enemyPool_2.Release(this.gameObject);
        }
        else if(enemyType== EnemyType.C)
        {
            spawner.enemyPool_3.Release(this.gameObject);
        }
        else if(enemyType== EnemyType.D)
        {
            spawner.enemyPool_4.Release(this.gameObject);
        }
        
    }

    IEnumerator ReleaseEffect()
    {
        //This portion is for the blood gush effect
        GameObject effect = FindObjectOfType<Effects>().bloodPool.Get();
        effect.transform.position = transform.position;
        effect.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(.3f);
        effects.bloodPool.Release(effect);

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anime.Play(fightAnimeString);
        }
        
    }

}
