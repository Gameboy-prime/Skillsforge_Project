using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneMove : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    
    void Update()
    {
        agent.SetDestination(playerPos.position + new Vector3(0,0,0));
        //agent.stoppingDistance = -1;
        transform.rotation= playerPos.rotation;
        
        
    }
}
