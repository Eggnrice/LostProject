using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ben : Player
{

    public Transform attackPoint;
    public Transform SattackPoint;
    public float attackRange = 0.5f;
    public float SattackRange = 0.5f;
    public LayerMask enemyLayers;
    public float punchDamage;
    
    internal override void Start()
    {
        base.Start();

    }

    internal override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("SAttack");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("Attack");
        }
    }

  void Attack()
    {
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D hitInfo in hitEnemies)
        {
            BossHealth boss = hitInfo.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage(punchDamage);
            }
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDamage(punchDamage);
            }



        }

    }
    public void SAttack()
    {
       Collider2D[] hitEnemiesSattack = Physics2D.OverlapCircleAll(SattackPoint.position, SattackRange, enemyLayers);

        foreach (Collider2D hitInfo in hitEnemiesSattack)
        {
            BossHealth boss = hitInfo.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage(punchDamage);
            }
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDamage(punchDamage);
            }

        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(SattackPoint.position, SattackRange);
    }
}
