using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFight : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform battleLine;

    

    // Update is called once per frame
    void Update()
    {
        
        

        
    }

    public void Attack()
    {
        //Check to see if the player is not dead before moving to face the enemy
        if (!CloneMultiplier.isDead)
        {
            agent.SetDestination(battleLine.position);
        }
    }
}
