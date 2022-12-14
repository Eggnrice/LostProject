using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float damage;
    void Update()
    {
        transform.position += transform.up * 5 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        BossHealth boss = collision.GetComponent<BossHealth>();
        if (player)
        {
            return;
        }

        if (enemy)
        {
            enemy.OnDamage(damage);
            Destroy(gameObject);
        }
        if(boss)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }


    }
}
