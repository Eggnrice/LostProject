using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] AudioSource shieldSound;
    [SerializeField] float amountDamage;

    public float coolDownTime = 15f;
    private float nextFireTime = 0f;

    private void Start()
    {
        spriteRenderer.enabled = false;
        circleCollider2D.enabled = false;
        //progressionDamage = 0.25f;
        //maxDamage = 100;
        //amountDamage = 100;
    }
    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown("space"))
            {
                nextFireTime = Time.time + coolDownTime;

                StartCoroutine(ShieldCoroutine());
            }
        }
    }

    IEnumerator ShieldCoroutine()
    {
        spriteRenderer.enabled = true;
        circleCollider2D.enabled = true;
        //shieldSound.Play();
        yield return new WaitForSeconds(3f);
        //shieldSound.Pause();
        spriteRenderer.enabled = false;
        circleCollider2D.enabled = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.OnDamage(amountDamage);
        }
    }
}
