using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxHP;
  
    [SerializeField] float speed;
    public float expToLevelUp;
    public int currentExp;
    public float currentHp;
    internal float currentLevel;
    internal bool m_FacingRight;
    protected Animator animator;
    bool isInvincible;
    protected bool isRunning;
    protected bool isAttacking;
   // private bool isDashing = false;
    public HealthBar healthBar;
    public ExpBar expBar;

    internal virtual void Start()
    {
        currentHp = maxHP;
        currentLevel = 1;
        // weapons[0].LevelUp();
        animator = GetComponent<Animator>();
        //StartCoroutine(IsAttackingCoroutine());
        // material = spriteRenderer.material;
        healthBar.SetMaxHealth(maxHP);
        expBar.SetMaxExp(expToLevelUp);
        expBar.SetExp(currentExp);
        
    }
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
    }
    internal virtual void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    internal virtual void AddExp()
    {
        currentExp++;
        expBar.SetExp(currentExp);
       if(currentExp == expToLevelUp)
        {
            currentExp = 0;
            expBar.SetExp(currentExp);
            expToLevelUp += 2;
            expBar.SetMaxExp(expToLevelUp);
        }
    }

    public void OnDamage(float enemyDamage)
    {
        if(!isInvincible)
        {
            currentHp -= enemyDamage;

            healthBar.SetHealth(currentHp);

            StartCoroutine(InvincibleCoroutine());
            if (currentHp <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Title");
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
  
}
