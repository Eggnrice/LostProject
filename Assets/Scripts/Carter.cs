using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carter : Player
{
    PlayerState carterState = PlayerState.Idle;
    protected override void Start()
    {
       
        base.Start();
    }

    protected override void Update()
    {
        switch (carterState)
        {
            case PlayerState.Running:
                animator.SetBool("isRunning", true);
                break;
            case PlayerState.Attacking:
                animator.SetBool("isAttacking", true);
                break; 

        }
        base.Update();
    }
}
