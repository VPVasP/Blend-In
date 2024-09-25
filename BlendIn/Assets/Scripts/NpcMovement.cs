using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class NpcMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        SetNewTarget(waypoints[0]);
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.1f && !agent.pathPending)
        {
            SetNextTarget();
        }
    }
    void SetNewTarget(Transform targetPosition)
    {
        agent.SetDestination(targetPosition.position);
    }
 

    void SetNextTarget()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
        SetNewTarget(waypoints[currentWaypointIndex]);
    }
}


