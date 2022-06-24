using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    private NavMeshAgent agent;

    private Player player;

    private SkeletonAnimations skeletonAnimations;

    [SerializeField]
    private Image _healthBar;

    [SerializeField]
    private float _healthTotal;
    
    private float _healthCurrent;

    private bool _isDead;

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

    private void onMove()
    {
        if (_isDead) {
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
}
