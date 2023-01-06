using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent = null;
    private CharacterAnimationController characterAnimationController = null;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        characterAnimationController = GetComponent<CharacterAnimationController>();
    }

    private void Update()
    {
        UpdateAnimator();
    }

    public Vector3 GetRandomPointOnNavMesh(float maxTravelDistance = Mathf.Infinity)
    {
        Vector3 randomPoint = Random.insideUnitSphere * maxTravelDistance;
        randomPoint += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, maxTravelDistance, NavMesh.AllAreas);
        return hit.position;
    }

    public bool HasPath()
    {
        return navMeshAgent.hasPath;
    }

    public void MoveTo(Vector3 newDestination)
    {
        navMeshAgent.SetDestination(newDestination);
    }

    public void Pause()
    {
        navMeshAgent.isStopped = true;
    }

    public void Resume()
    {
        navMeshAgent.isStopped = false;
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        characterAnimationController.SetLocomotionSpeed(speed);
    }
}
