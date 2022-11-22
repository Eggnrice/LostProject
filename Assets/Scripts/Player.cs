using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    private Vector2 moveInput;
    public Rigidbody2D rb;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCooldownCounter;
    public float moveSpeed;




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
        activeMoveSpeed = moveSpeed; 
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb.velocity = moveInput * activeMoveSpeed ; 
       // transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;


        if (moveInput.x < 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (moveInput.x > 0 && m_FacingRight)
        {
            Flip();
        }

        isRunning = moveInput.x != 0 || moveInput.y != 0;

        animator.SetBool("isRunning", isRunning);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter<= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCooldownCounter = dashCooldown;

            }
        }
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }
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
