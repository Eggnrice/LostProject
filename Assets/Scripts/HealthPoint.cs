using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] AudioClip eatingSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (player.currentHp < player.maxHP)
            {
                player.currentHp += player.maxHP / 4f;
                if (player.currentHp > player.maxHP)
                {
                    player.currentHp = player.maxHP;
                }
            }
            //AudioSource.PlayClipAtPoint(eatingSound, transform.position);
            Destroy(gameObject);
        }
    }
}
