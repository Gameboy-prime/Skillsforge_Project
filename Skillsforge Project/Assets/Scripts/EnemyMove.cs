using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    private Transform playerPos;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = FindObjectOfType<PlayerFight>().transform;
        enemyAgent.SetDestination(playerPos.position);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player Clone"))
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<CapsuleCollider>().enabled = false ;
            other.GetComponentInChildren<Animator>().SetTrigger("slash");
            //Debug.Log("Has entered player clone Trigger");
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            FindObjectOfType<CloneMultiplier>().spawnList.Remove(other.gameObject);
            FindObjectOfType<EnemySpawner>().enemyCount--;
            
            if (CloneMultiplier.playerNum < 0)
            {
                CloneMultiplier.playerNum = 0;
            }
            Destroy(effect, .2f);

            Destroy(other.gameObject, 1.1f);
            CloneMultiplier.playerNum -= 1;

            Destroy(gameObject,1.6f);

        }
    }
}
