using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndGame : MonoBehaviour
{

    public static bool endGame;

    //Reference
    //public EnemySpawner enemySpawner;
    public Transform endPoint;
    public GameObject player;
    public EnemySpawner enemySpawner;
    public WallSpawner wallSpawner;
    public PowerupSpawner powerUpSpawner;
    public Statistics stats;
    public GameOver gameOver;
    public GameEnd gameEnd;
   

    //FX
    public AudioSource source;
    
    public float endTime=20f;

    private void Start()
    {
        GameData.currentGameCoin= 0;
        endGame = false;

    }

    private void Update()
    {
        //Debug.Log($"The Number of Zombie is {EnemySpawner.EnemyDeadCount} And the Number of possible enemy is {enemySpawner.numPossibleEnemy}");
        if(EnemySpawner.EnemyDeadCount >= EnemySpawner.numPossibleEnemy && !endGame)
        {
            endGame = true;
            Debug.Log("it can actually end phase");
            EndPhase();
        }
    }






    public void EndPhase()
    {
        Debug.Log("The Ende Phase function is called");
        StartCoroutine(PhaseEnd());
        /*if (!CloneMultiplier.isDead)
        {
            StartCoroutine(PhaseEnd());
        }*/


    }

    IEnumerator PhaseEnd()
    {
        Debug.Log("THe Phase is Ending");
        Multiplier[] multiplier = FindObjectsOfType<Multiplier>();

        for(int i = 0; i < multiplier.Length; i++)
        {
            multiplier[i].GetComponent<BoxCollider>().enabled= false;
        }
        wallSpawner.GetComponent<WallSpawner>().enabled = false;
        enemySpawner.GetComponent<EnemySpawner>().enabled= false;
        powerUpSpawner.GetComponent<PowerupSpawner>().enabled = false;

        player.GetComponent<CapsuleCollider>().enabled = false ;
        player.GetComponent<Movement>().enabled = false;
        
       // player.GetComponent<PlayerFight>().Attack();
        yield return new WaitForSeconds(1);

        
        
        
        
        yield return new WaitForSeconds(1.5f);
        if (endGame)
        {
            stats.ShowStats();
            gameEnd.SaveProgress();
        }
        else
        {
            gameOver.ShowGameOver();
        }
        


        



    }

   

    
    
}
