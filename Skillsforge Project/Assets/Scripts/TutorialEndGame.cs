using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialEndGame : MonoBehaviour
{
    public static bool isFighting;

    //Reference
    //public EnemySpawner enemySpawner;
    public Transform endPoint;
    public GameObject player;
    public EnemySpawner enemySpawner;
    public TutorialWallSpawner wallSpawner;
    public Animator camAnime;

    //FX
    public AudioSource source;
    public AudioClip ChargeClip;
    public AudioSource fightClip;
    public float endTime = 20f;

    public GameObject king;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Invoke(nameof(EndPhase), endTime);

    }



    public void EndPhase()
    {
        if (!TutorialCloneMultiplier.isDead)
        {
            StartCoroutine(PhaseEnd());
        }


    }

    IEnumerator PhaseEnd()
    {
        TutorialMultiplier[] multiplier = FindObjectsOfType<TutorialMultiplier>();

        for (int i = 0; i < multiplier.Length; i++)
        {
            multiplier[i].GetComponent<BoxCollider>().enabled = false;
        }
        wallSpawner.GetComponent<TutorialWallSpawner>().enabled = false;

        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<TutorialMovement>().enabled = false;
        player.GetComponent<TutorialPlayerFight>().enabled = true;
        // player.GetComponent<PlayerFight>().Attack();
        yield return new WaitForSeconds(1);
        source.PlayOneShot(ChargeClip);
        enemySpawner.EnemySpawn();
        camAnime.Play("CamFightAnim");
        isFighting = true;
        yield return new WaitForSeconds(1.5f);
        king.AddComponent<CapsuleCollider>();
        king.GetComponent<CapsuleCollider>().isTrigger = true;



    }

    public void FightOver()
    {
        if (isFighting && (enemySpawner.enemyCount <= 0 && TutorialCloneMultiplier.playerNum > 0))
        {
            Debug.Log("The fight Over Function has been called");
            player.GetComponent<TutorialPlayerFight>().enabled = false;
            player.GetComponentInChildren<Animator>().Play("Running");
            player.GetComponent<NavMeshAgent>().SetDestination(endPoint.position);
            if (player.GetComponent<CapsuleCollider>().enabled != true)
            {
                player.GetComponent<CapsuleCollider>().enabled = true;

            }
            fightClip.Stop();

        }


    }

    public void CheckPlayer()
    {
        Debug.Log("The check player function has been called");
        if (isFighting && (enemySpawner.enemyCount > 0 && TutorialCloneMultiplier.playerNum == 1))
        {

            Debug.Log("The Player is dead");
            player.GetComponent<TutorialCloneMultiplier>().Dying();
            
            player.GetComponentInChildren<Animator>().SetTrigger("die");

        }

    }



    private void Update()
    {
        FightOver();
    }
}
