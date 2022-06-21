using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    private NavMeshAgent agent;

    private Player player;

    private SkeletonAnimations skeletonAnimations;

    void Start()
    {
        player = FindObjectOfType<Player>();
        skeletonAnimations = GetComponent<SkeletonAnimations>();
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        onMove();
    }

    private void onMove()
    {
        agent.SetDestination(player.transform.position);

        transform.eulerAngles = ((player.transform.position.x - transform.position.x) > 0)
            ? new Vector2(0, 0)
            : new Vector2(0, 180);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance) {
            skeletonAnimations.onTransition(2);
            return;
        }

        skeletonAnimations.onTransition(1);
    }
}
