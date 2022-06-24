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

    private Skeleton skeleton;

    private Animator skeletonAnimations;

    private PlayerAnimations playerAnimations;

    void Start()
    {
        skeleton = GetComponent<Skeleton>();
        skeletonAnimations = GetComponent<Animator>();
        playerAnimations = FindObjectOfType<PlayerAnimations>();
    }

    public void onTransition(int transition)
    {
        skeletonAnimations.SetInteger("transition", transition);
    }

    // Attack
    private void onAttack()
    {
        if (skeleton.isDead) {
            return;
        }

        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radiusAttackPoint, playerLayer);

        if (hit == null) {
            return;
        }
        
        playerAnimations.onHitting();
    }

    // Hitting
    public void onHitting()
    {
        skeleton.healthCurrent--;

        skeleton.healthBar.fillAmount = skeleton.healthCurrent / skeleton.healthTotal;

        if (skeleton.healthCurrent <= 0f) {
            skeleton.isDead = true;
            skeletonAnimations.SetTrigger("isDeathing");

            Destroy(gameObject, 1f);
            return;
        }

        skeletonAnimations.SetTrigger("isHitting");
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(attackPoint.position, radiusAttackPoint);
    }
}
