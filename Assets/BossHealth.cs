using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public float health;
	

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(float damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 10)
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
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
