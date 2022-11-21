using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] float speed;
   [SerializeField] float maxHP;
   [SerializeField] GameObject bulletPrefab;
   [SerializeField] Transform firePoint;
// [SerializeField] BaseWeapon[] weapons;

    internal int currentExp;
    internal float currentHp;
    internal float currentLevel;
    internal bool m_FacingRight;
    protected Animator animator;
    private bool isInvincible;
    protected bool isRunning;
    protected bool isAttacking;


    protected enum PlayerState
    {
        Idle,
        Running,
        Attacking
    }

    protected virtual void Start()
    {
        currentHp = maxHP;
        currentLevel = 1f;
        // weapons[0].LevelUp();
        animator = GetComponent<Animator>();
        StartCoroutine(IsAttackingCoroutine());
    }

    // Update is called once per frame
    protected virtual void Update()
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

        isRunning = inputX != 0 || inputY != 0;

        animator.SetBool("isRunning", isRunning);
    }

    internal virtual void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    internal virtual void AddExp()
    {
        currentExp++;
        if(currentLevel%2 == 0)
        {
            Time.timeScale = 0;
            //Menu appears
        }
    }

    internal virtual void OnDamage(float enemyDamage)
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

        isInvincible = true;
        //material.SetFloat("_Flash", 0.33f);
        yield return new WaitForSeconds(0.5f);
        //material.SetFloat("_Flash", 0);
        isInvincible = false;
    }
    IEnumerator IsAttackingCoroutine()
    {
        while (true) { 
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(2f);
        }
    }

    void Bullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
