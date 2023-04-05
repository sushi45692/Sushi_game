using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTarget;
    public float minDistanceAway = 10f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {

            // Moves the agent to the player
            agent.destination = playerTarget.position;
        }
    }
}
