using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Animator anime;
    private Transform playerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        anime=GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = FindObjectOfType<PlayerFight>().transform;
        if(enemyAgent != null)
        {
            //Vector3 destination = new Vector3(0, 0, playerPos.position.z);
            enemyAgent.SetDestination(playerPos.position);

        }

    
        
    }

  
}
