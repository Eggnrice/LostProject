using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxHp;
    [SerializeField] GameObject[] consumible;
    [SerializeField] GameObject crystal;
    public float damage;

    protected Player player;
    protected float currentHP;
    protected Animator animator;

    private float damageInterval = 1f; 
    private float timeSinceLastDamage = 0f;

    protected enum EnemyState
    {
        Idle,
        Chasing,
        Attacking
    }
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentHP = maxHp;
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;

        Vector3 direction = destination - source;
        direction.Normalize();

        transform.position += direction * Time.deltaTime * speed;

        int scaleX = direction.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);

    }

     public virtual void OnDamage(float playerDamage)
     {
        currentHP -= playerDamage;
        if (currentHP <= 0)
        {
            int random = UnityEngine.Random.Range(0, consumible.Length - 1);
          
            if(consumible[random]!=null) Instantiate(consumible[random], transform.position, Quaternion.identity);
            
            if(crystal!=null) Instantiate(crystal,transform.position, Quaternion.identity); 
            
            Destroy(gameObject);
        }
     }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
       Player player = collision.GetComponent<Player>();
       if(player)
       {
            player.OnDamage(damage);       

       }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        timeSinceLastDamage += Time.deltaTime;

        if (timeSinceLastDamage >= damageInterval && player) 
        {
            player.OnDamage(damage);
            timeSinceLastDamage = 0f;
        }

    }
}

