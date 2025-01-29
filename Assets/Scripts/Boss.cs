using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    private float damageInterval = 1f;
    private float timeSinceLastDamage = 0f;
    public float damage = 10f;

    public bool isFlipped = true;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.OnDamage(damage);
        }
    }

   
}
