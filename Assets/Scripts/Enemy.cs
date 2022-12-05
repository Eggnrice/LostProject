using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxHp;
    [SerializeField] GameObject[] consumible;
    [SerializeField] float damage;

    protected Player player;
    public float currentHP;
    protected Animator animator;

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

    internal virtual void OnDamage(float playerDamage)
    {
        currentHP -= playerDamage;
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            int random = UnityEngine.Random.Range(0, consumible.Length + 1);
            Instantiate(consumible[random], transform.position, Quaternion.identity);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
       Player player = collision.GetComponent<Player>();
       if(player)
       {
            player.OnDamage(damage);

       }

    }
}

