using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : BaseWeapon
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float bulletSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if(player)
        {
            return;
        }
        if (enemy)
        {
            enemy.OnDamage(Damage);
            Destroy(gameObject);
        }
    }


}
