using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialPlayerFight : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform battleLine;



    // Update is called once per frame
    void Update()
    {
        if (!TutorialCloneMultiplier.isDead)
        {
            if (FindObjectOfType<TutorialEnemyMove>().transform.position != null)
            {
                Vector3 pos = FindObjectOfType<TutorialEnemyMove>().transform.position;
                agent.SetDestination(pos);
            }

        }

        


    }

    public void Attack()
    {
        //Check to see if the player is not dead before moving to face the enemy

    }
}
