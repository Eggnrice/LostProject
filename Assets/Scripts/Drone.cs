using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float ratio;
    [SerializeField] Transform player;
    public Animator animator; 
    public float speed = 5;
    private bool m_FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(IsAttackingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        float targetZ = transform.position.z;

        var playerPosition = new Vector3(targetX, targetY, targetZ);
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);

        if (player.transform.rotation.y == 0f && m_FacingRight)
        {
            Flip();
            Debug.Log("estoy leyendo esta huevonada");
        }
        if (player.transform.rotation.y == 180f && !m_FacingRight)
        {
            Flip();
            Debug.Log("estoy leyendo la segunda huevonada");
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Bullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator IsAttackingCoroutine()
    {
        while (true)
        {
            int i;
            for (i = 0; i < ratio; i++)
            {
                
                animator.SetTrigger("isAttacking");
                yield return new WaitForSeconds(0.819f);

            }
            yield return new WaitForSeconds(5f);

        }
    }
}
