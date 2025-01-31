using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float bulletSpeed;
    [SerializeField] AudioClip audioClip;
    void Start()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    void Update()
    {
        transform.position += transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        BossHealth boss = collision.GetComponent<BossHealth>();
        if(player)
        {
            return;
        }
        if (enemy)
        {
            enemy.OnDamage(Damage);
            Destroy(gameObject);
        }
        if (boss)
        {
            boss.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }


}
