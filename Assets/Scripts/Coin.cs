using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSound;
    Rigidbody2D rb;
    bool hasTarget;
    Vector3 targetPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            try 
            {
                TitleManager.saveData.goldCoins++; 
            }
            catch (Exception e) 
            {
                Debug.Log(e);

            }
           
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * 5f;
        }
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }
}
