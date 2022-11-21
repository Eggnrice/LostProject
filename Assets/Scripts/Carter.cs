using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carter : Player
{
    [SerializeField] Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime; 

    PlayerState carterState = PlayerState.Idle;
    protected override void Start()
    {
        dashTime = startDashTime;
        base.Start();
    }

    protected override void Update()
    {
        //switch (carterState)
        //{
        //    case PlayerState.Running:
        //        animator.SetBool("isRunning", true);
        //        break;
        //    case PlayerState.Attacking:
        //        animator.SetBool("isAttacking", true);
        //        break; 

        //}
        
        
      if (dashTime > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            dashTime -= Time.deltaTime;
            if (m_FacingRight == true)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
            else
            {
                rb.velocity = Vector2.left * dashSpeed;
            }
            if (dashTime <= 0)
            {
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            }
        }

        animator.SetBool("isRunning", isRunning);

        //if (Input.GetButton("space"))
        //{
        //    animator.SetBool("isAttacking", true);
        //}

        base.Update();
    }
}
