using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialEnemyMove : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Animator anime;
    private Transform playerPos;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        anime = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = FindObjectOfType<TutorialPlayerFight>().transform;
        if (enemyAgent != null && !TutorialCloneMultiplier.isDead)
        {
            enemyAgent.SetDestination(playerPos.position);

        }

        else
        {
            enemyAgent.SetDestination(playerPos.position + new Vector3(0, 0, -42));
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        //StartCoroutine(TriggerEnter(other));


    }

    /*IEnumerator TriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Clone") && !TutorialCloneMultiplier.isDead)
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponentInChildren<Animator>().SetTrigger("slash");

            this.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<NavMeshAgent>().enabled = false;

            yield return new WaitForSeconds(2);
            //Debug.Log("Has entered player clone Trigger");

            FindObjectOfType<TutorialCloneMultiplier>().spawnList.Remove(other.gameObject);
            FindObjectOfType<EnemySpawner>().enemyCount--;

            if (TutorialCloneMultiplier.playerNum < 0)
            {
                TutorialCloneMultiplier.playerNum = 0;
            }
            TutorialCloneMultiplier.playerNum -= 1;
            TutorialCloneMultiplier.ZombieNum += 1;
            anime.Play("Zombie Dying");

            other.GetComponentInChildren<Animator>().Play("Dying");
            other.GetComponent<CloneMove>().enabled = false;

            this.GetComponent<TutorialEnemyMove>().enabled = false;





        }

    }*/
}
