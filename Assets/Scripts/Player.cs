using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] float maxHP;
   [SerializeField] GameObject bulletPrefab;
   [SerializeField] Transform firePoint;
   [SerializeField] float speed;
   //[SerializeField] SpriteRenderer spriteRenderer;

   // Material material;

    // [SerializeField] BaseWeapon[] weapons;
    public float teleportDistance;
    internal int currentExp;
    public float currentHp;
    internal float currentLevel;
    internal bool m_FacingRight;
    protected Animator animator;
    bool isInvincible;
    protected bool isRunning;
    protected bool isAttacking;
    public int ratio;
    private bool isDashing = false;

    internal virtual void Start()
    {
        currentHp = maxHP;
        currentLevel = 1;
        // weapons[0].LevelUp();
        animator = GetComponent<Animator>();
        StartCoroutine(IsAttackingCoroutine());
       // material = spriteRenderer.material;
        
    }

    // Update is called once per frame
    internal virtual void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;
        if (inputX < 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (inputX > 0 && m_FacingRight)
        {
            Flip();
        }

        bool isRunning = inputX != 0;

        animator.SetBool("isRunning", isRunning);

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Dash");
        }
    }


    internal virtual void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //internal virtual void AddExp()
    //{
    //    currentExp++;
    //    if(currentLevel%2 == 0)
    //    {
    //        Time.timeScale = 0;
    //        //Menu appears
    //    }
    //}

    public void OnDamage(float enemyDamage)
    {
        if(!isInvincible)
        {
            currentHp -= enemyDamage;

            StartCoroutine(InvincibleCoroutine());
            if (currentHp <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
    IEnumerator InvincibleCoroutine()
    {
        Debug.Log("I got hit");
        isInvincible = true;
       // material.SetFloat("_Flash", 0.33f);
        yield return new WaitForSeconds(1f);
       // material.SetFloat("_Flash", 0);
        isInvincible = false;
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

    void Bullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Teleport()
    {
        isDashing = true;
        if (!m_FacingRight)
        {
            transform.position = new Vector2(transform.position.x + teleportDistance, transform.position.y);
        }
        else if(m_FacingRight)
        {
            transform.position = new Vector2(transform.position.x - teleportDistance, transform.position.y);
        }
        
    }

  
}
