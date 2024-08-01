using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneMove : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private NavMeshAgent agent;

    public Animator anime;
    private bool isMoveAnime=false;
    private bool isIdleAnime;

    
    
    void Update()
    {
        if (Movement.isMoving && !isMoveAnime)
        {
            Debug.Log("The Move animation trigger was triggered");
            anime.SetTrigger("Move");
            

        }
        else
        {
            Invoke(nameof(WaitForAnimation), .2f);
        }

        if (Movement.isMoving)
        {
            
            isMoveAnime = true;
            
            MoveToPlayer();
        }

        else
        {
            transform.rotation = playerPos.rotation;
            isMoveAnime =false;
            
        }

    }

    private void WaitForAnimation()
    {
        anime.SetTrigger("Idle");
        isMoveAnime = false;
    }

    private void MoveToPlayer()
    {
        transform.rotation = playerPos.rotation;
        agent.SetDestination(playerPos.position + new Vector3(0, 0, .5f));
        //agent.stoppingDistance = -1;
        transform.rotation = playerPos.rotation;
    }
}
