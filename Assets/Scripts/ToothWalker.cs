using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothWalker : Enemy
{
    float waitTimer = 2f;
    [SerializeField] float distanceToPlayer;
    protected override void Start()
    {
        base.Start();
    }
    private enum ToothState
    {
       Idle,
       Chasing,
       Attacking
    }
        ToothState toothState = ToothState.Idle;
    protected override void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        switch (toothState)
        {
            case ToothState.Idle:
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0)
                {
                    toothState = ToothState.Chasing;
                }
                break;
            case ToothState.Chasing:
                animator.SetBool("isWalking", true);
                base.Update();

                if (distance <= distanceToPlayer)
                {
                    toothState = ToothState.Attacking;
                }
                break;
            case ToothState.Attacking:
               
                animator.SetBool("isWalking", false);
                animator.SetBool("Attack", true);
                base.Update();
                if(distance > distanceToPlayer)
                {
                    animator.SetBool("Attack", false);
                    toothState = ToothState.Chasing;
                }
                


                break;
            default:
                break;
        }
    }
   
}
