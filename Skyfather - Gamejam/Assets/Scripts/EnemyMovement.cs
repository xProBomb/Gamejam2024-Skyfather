using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 target;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        
    }

    void FixedUpdate()
    {
        target = GameObject.Find("Player").transform.position;
        if (agent.pathStatus != NavMeshPathStatus.PathPartial)
        {
            agent.SetDestination(target);
        }
        else if (agent.pathStatus == NavMeshPathStatus.PathPartial && agent.remainingDistance > 0.5f)
        {
            agent.SetDestination(GetClosestReachablePoint(agent));   
        }
        else
        {
            agent.SetDestination(target);
        }
    }

    Vector3 GetClosestReachablePoint(NavMeshAgent agent)
    {
        if (agent.path.corners.Length > 0)
        {
            return agent.path.corners[agent.path.corners.Length - 1];
        }
        return agent.transform.position;
    }

}
