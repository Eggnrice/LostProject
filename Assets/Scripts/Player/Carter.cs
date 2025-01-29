using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carter : Player
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
   
    private bool isDashing = false;
    public float teleportDistance;
    public int ratio;
    internal override void Start()
    {
        base.Start();
        StartCoroutine(IsAttackingCoroutine());

    }
    internal override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Dash");
        }
       
    }
    IEnumerator IsAttackingCoroutine()
    {
        while (true)
        {
            int i;
            for (i = 0; i < ratio; i++)
            {
                if (isDashing == true)
                {
                    yield return new WaitForSeconds(0.350f);
                    isDashing = false;
                }
                animator.SetBool("isAttacking", true);
                yield return new WaitForSeconds(0.41f);

            }
            animator.SetBool("isAttacking", false);
            yield return new WaitForSeconds(5f);

        }
    }
    void Teleport()
    {
        isDashing = true;
        if (!m_FacingRight)
        {
            transform.position = new Vector2(transform.position.x + teleportDistance, transform.position.y);
        }
        else if (m_FacingRight)
        {
            transform.position = new Vector2(transform.position.x - teleportDistance, transform.position.y);
        }

    }
    void Bullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


}
