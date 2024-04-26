using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneMove : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPos.position);
        //agent.stoppingDistance = -1;
        transform.rotation= playerPos.rotation;
        
        
    }
}
