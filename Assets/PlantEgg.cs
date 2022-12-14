using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEgg : Enemy
{
    EnemyState plantEggState = EnemyState.Idle;
    float waitTimer = 2f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask players;
    public float distanceToPlayer;

    protected override void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        switch (plantEggState)
        {
            case EnemyState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    plantEggState = EnemyState.Chasing;
                }
                break;
            case EnemyState.Chasing:
                animator.SetBool("isRunning", true);
                base.Update();

                if (distance <= distanceToPlayer)
                {
                    plantEggState = EnemyState.Attacking;
                }
                break;
            case EnemyState.Attacking:

                animator.SetBool("isRunning", false);
                animator.SetTrigger("Attack");

                plantEggState = EnemyState.Idle;
                waitTimer = 5f;


                break;
            default:
                break;
        }

    }
        void Attack()
        {
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, players);

            foreach (Collider2D hitInfo in hitPlayers)
            {
             
                Player player = hitInfo.GetComponent<Player>();
                if (player != null)
                {
                    player.OnDamage(damage);
                }

            }
        }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


