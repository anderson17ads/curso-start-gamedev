using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimations : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float radiusAttackPoint;

    [SerializeField]
    private LayerMask playerLayer;

    private Animator skeletonAnimations;

    private PlayerAnimations playerAnimations;

    void Start()
    {
        skeletonAnimations = GetComponent<Animator>();
        playerAnimations = FindObjectOfType<PlayerAnimations>();
    }

    void Update()
    {
        
    }

    public void onTransition(int transition)
    {
        skeletonAnimations.SetInteger("transition", transition);
    }

    private void onAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radiusAttackPoint, playerLayer);

        if (hit == null) {            
            return;
        }
        
        playerAnimations.onHitting();
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(attackPoint.position, radiusAttackPoint);
    }
}
