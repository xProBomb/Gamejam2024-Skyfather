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
        FaceTarget();
    }

    Vector3 GetClosestReachablePoint(NavMeshAgent agent)
    {
        if (agent.path.corners.Length > 0)
        {
            return agent.path.corners[agent.path.corners.Length - 1];
        }
        return agent.transform.position;
    }

    void FaceTarget()
    {
        Vector3 vel = agent.velocity.normalized;
        if (agent.velocity != Vector3.zero)
        {
            Vector3 moveDirection = new Vector3(agent.velocity.x, agent.velocity.y, 0f);

            if (moveDirection != Vector3.zero)
            {
                // Get the angle in degrees
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

                // Snap the angle to one of the eight directions
                angle = SnapAngleToDirection(angle);

                // Rotate the AI to the snapped direction
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }
        }
    }

    float SnapAngleToDirection(float angle)
    {
        // Normalize the angle to be within [0, 360]
        if (angle < 0) angle += 360f;

        // Define the directions in d egrees
        float[] directions = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f };

        // Find the closest direction
        float closestDirection = directions[0];
        float minDifference = Mathf.Abs(Mathf.DeltaAngle(angle, closestDirection));

        foreach (float dir in directions)
        {
            float difference = Mathf.Abs(Mathf.DeltaAngle(angle, dir));
            if (difference < minDifference)
            {
                minDifference = difference;
                closestDirection = dir;
            }
        }
        if (closestDirection == 225f) // Down-Left
        {
            closestDirection = 180f; // Snap to Left
        }
        else if (closestDirection == 315f) // Down-Right
        {
            closestDirection = 0f; // Snap to Right
        }
        return closestDirection;
    }
}
