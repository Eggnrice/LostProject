using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public float health;
	public float maxHealth;
	public GameObject deathEffect;

	public bool isInvulnerable = false;

    private void Start()
    {
		maxHealth = health;
    }

    public void TakeDamage(float damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= maxHealth/2)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
