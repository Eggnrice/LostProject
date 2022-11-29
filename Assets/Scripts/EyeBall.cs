using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : Enemy
{
    EnemyState eyeBallState = EnemyState.Idle;
    float waitTimer = 2f;
    protected override void Update()
    {
        base.Update();

        switch (eyeBallState)
        {
            case EnemyState.Idle:
                waitTimer -= Time.deltaTime;
                break;
            case EnemyState.Chasing:
                animator.SetBool("isWalking", true);
                break;
            case EnemyState.Attacking:
                animator.SetBool("isWalking", false);
                animator.SetBool("Attack", true);

                waitTimer = 5f;

                break;
            default:
                break;
        }
    }

}
