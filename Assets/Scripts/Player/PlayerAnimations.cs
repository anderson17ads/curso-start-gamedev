using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float radiusAttackPoint;

    [SerializeField]
    private LayerMask enemyLayer;

    private Player player;

    private Animator playerAnimations;

    private CastingFarm castingFarm;

    private bool isHitting;

    [SerializeField]
    private float recoveryTime;

    private float timeCount;
    
    void Start()
    {
        player = GetComponent<Player>();
        playerAnimations = GetComponent<Animator>();
        castingFarm = FindObjectOfType<CastingFarm>();
    }

    void Update()
    {
        onMove();
        onRun();
        onCutting();
        onDiging();
        onWatering();
        onCasting();
        onHammering();
        endHammering();
        onRecoveryTime();
    }

    // Move
    private void onMove()
    {
        int transition = 0;        

        if (player.direction.sqrMagnitude > 0) {
            transition = 1;

            if (player.isRolling && !playerAnimations.GetCurrentAnimatorStateInfo(0).IsName("roll")) {
                playerAnimations.SetTrigger("isRoll");
            }
        }

        playerAnimations.SetInteger("transition", transition);
        
        if (player.direction.x == 0) {
            return;
        }

        transform.eulerAngles = player.direction.x < 0 
            ? new Vector2(0, 180) 
            : new Vector2(0, 0);
    }

    // Run
    private void onRun()
    {
        if (player.isRunning && player.direction.sqrMagnitude > 0) {
            playerAnimations.SetInteger("transition", 2);
        }
    }

    // Cutting
    private void onCutting()
    {
        if (player.isCutting) {
            playerAnimations.SetInteger("transition", 3);
        }
    }

    private void endCutting(string message)
    {
        if (message.Equals("PlayerCuttingEnded")) {
            playerAnimations.SetInteger("transition", 0);
            player.isCutting = false;
            player.speed = player.initialSpeed;
        }
    }

    // Diging
    private void onDiging()
    {
        if (player.isDiging) {
            playerAnimations.SetInteger("transition", 4);
        }
    }

    private void endDiging(string message)
    {
        if (message.Equals("PlayerDigingEnded")) {
            playerAnimations.SetInteger("transition", 0);
            player.isDiging = false;
            player.speed = player.initialSpeed;
        }
    }

    // Watering
    private void onWatering()
    {
        if (player.isWatering) {
            playerAnimations.SetInteger("transition", 5);
        }
    }

    private void endWatering(string message) 
    {
        if (message.Equals("PlayerWateringEnded")) {
            playerAnimations.SetInteger("transition", 0);
            player.isWatering = false;
            player.speed = player.initialSpeed;
        }
    }

    // Casting
    private void onCasting()
    {
        if (player.isCasting) {
            playerAnimations.SetInteger("transition", 6);
        }
    }

    private void endCasting(string message)
    {
        if (message.Equals("PlayerCastingEnded")) {
            playerAnimations.SetInteger("transition", 0);
            player.isCasting = false;
            player.speed = player.initialSpeed;

            castingFarm.addFish();
        }
    }

    // Hammering
    private void onHammering()
    {
        if (player.isHammering) {
            playerAnimations.SetBool("isHammering", true);
        }
    }

    private void endHammering()
    {
        if (!player.isHammering) {
            playerAnimations.SetBool("isHammering", false);
        }
    }

    // Hitting
    public void onHitting()
    {
        if (!isHitting) {
            playerAnimations.SetTrigger("isHitting");
            isHitting = true;
        }
    }

    // Recovery Time
    private void onRecoveryTime()
    {
        if (!isHitting) {
            return;
        }

        timeCount += Time.deltaTime;

        if (timeCount >= recoveryTime) {
            isHitting = false;
            timeCount = 0f;
        }
    }

    // Attack
    private void onAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radiusAttackPoint, enemyLayer);

        if (hit == null) {
            return;
        }

        hit.GetComponent<SkeletonAnimations>().onHitting();
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(attackPoint.position, radiusAttackPoint);
    }
}
