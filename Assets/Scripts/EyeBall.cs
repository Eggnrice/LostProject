using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : Enemy
{
    EnemyState eyeBallState = EnemyState.Idle;
    float waitTimer = 2f;
    //private bool isGettingHit = false;
    [SerializeField] GameObject attackPoint;
    [SerializeField] BoxCollider2D boxCollider;


    protected override void Start()
    {
        base.Start();
        boxCollider.enabled = false;
    }

    protected override void Update()
    {

        switch (eyeBallState)
        {
            case EnemyState.Idle:
                waitTimer -= Time.deltaTime;
                if(waitTimer <= 0)
                {
                    eyeBallState = EnemyState.Chasing;
                }
                break;
            case EnemyState.Chasing:
                animator.SetBool("isWalking", true);
                base.Update();

                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < 2f)
                {
                    eyeBallState = EnemyState.Attacking;
                }
                break;
            case EnemyState.Attacking:
                //if(isGettingHit == true)
                //{
                //    eyeBallState = EnemyState.Idle;
                //    isGettingHit = false;
                //    waitTimer = 5f;
                //}
                animator.SetBool("isWalking", false);
                animator.SetTrigger("Attack");

                eyeBallState = EnemyState.Idle; 
                waitTimer = 5f;


                break;
            default:
                break;
        }

    }
       
    public void BoxActive()
    {
        StartCoroutine(boxColliderActivate());
    }
    IEnumerator boxColliderActivate()
    {
        boxCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        boxCollider.enabled = false;
    }
}
