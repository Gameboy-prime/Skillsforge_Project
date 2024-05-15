using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndGame : MonoBehaviour
{

    public static bool isFighting;

    //Reference
    //public EnemySpawner enemySpawner;
    public Transform endPoint;
    public GameObject player;
    public EnemySpawner enemySpawner;
    public WallSpawner wallSpawner;
    public Animator camAnime;

    //FX
    public AudioSource source;
    public AudioClip ChargeClip;
    public AudioSource fightClip;
    public float endTime=20f;

    public GameObject king;
    // Start is called before the first frame update
    void Start()
    {
        endTime = Difficulty.difficulty * 30;
        Invoke(nameof(EndPhase), endTime);
        
    }


    private void Update()
    {
        
    }




    public void EndPhase()
    {
        if (!CloneMultiplier.isDead)
        {
            StartCoroutine(PhaseEnd());
        }
        

    }

    IEnumerator PhaseEnd()
    {
        Multiplier[] multiplier = FindObjectsOfType<Multiplier>();

        for(int i = 0; i < multiplier.Length; i++)
        {
            multiplier[i].GetComponent<BoxCollider>().enabled= false;
        }
        wallSpawner.GetComponent<WallSpawner>().enabled = false;

        player.GetComponent<CapsuleCollider>().enabled = false ;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<PlayerFight>().enabled = true;
       // player.GetComponent<PlayerFight>().Attack();
        yield return new WaitForSeconds(1);
        source.PlayOneShot(ChargeClip);
        enemySpawner.EnemySpawn();
        camAnime.Play("CamFightAnim");
        isFighting= true;
        yield return new WaitForSeconds(1.5f);
        king.AddComponent<CapsuleCollider>();
        king.GetComponent<CapsuleCollider>().isTrigger = true;



    }

    public void FightOver()
    {
        /*if(isFighting && (enemySpawner.enemyCount<=0  && CloneMultiplier.playerNum>0))
        {
            Debug.Log("The fight Over Function has been called");
            player.GetComponent<PlayerFight>().enabled=false;
            player.GetComponentInChildren<Animator>().Play("Running");
            player.GetComponent<NavMeshAgent>().SetDestination(endPoint.position);
            if (player.GetComponent<CapsuleCollider>().enabled != true)
            {
                player.GetComponent<CapsuleCollider>().enabled = true;

            }
            fightClip.Stop();

        }*/

        
    }

    public void CheckPlayer()
    {
        /*Debug.Log("The check player function has been called");
        if (isFighting && (enemySpawner.enemyCount > 0 && CloneMultiplier.playerNum == 1))
        {

            Debug.Log("The Player is dead");
            player.GetComponent<CloneMultiplier>().Dying();
            player.GetComponentInChildren<Animator>().SetTrigger("die");

        }*/

    }

    
}
