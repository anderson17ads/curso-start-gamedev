using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    private NavMeshAgent agent;

    private SkeletonAnimations skeletonAnimations;

    private Player player;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private float radius;

    [SerializeField]
    private Image _healthBar;

    [SerializeField]
    private float _healthTotal;
    
    private float _healthCurrent;

    private bool _isDead;

    private bool isCollision;

    public Image healthBar
    {
        get { return _healthBar; }
        set { _healthBar = value; }
    }

    public float healthTotal
    {
        get { return _healthTotal; }
        set { _healthCurrent = value; }
    }

    public float healthCurrent
    {
        get { return _healthCurrent; }
        set { _healthCurrent = value; }
    }

    public bool isDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        skeletonAnimations = GetComponent<SkeletonAnimations>();
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        _healthCurrent = _healthTotal;
    }

    void Update()
    {
        onMove();
    }

    private void FixedUpdate() {
        onDetectPlayer();
    }

    private void onMove()
    {
        if (_isDead || !isCollision) {
            return;
        }

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

    private void onDetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if (hit != null) {
            isCollision = true;
            agent.isStopped = false;
            return;
        }

        isCollision = false;
        skeletonAnimations.onTransition(0);
        agent.isStopped = true;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
