using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHealthPoint : MonoBehaviour
{
    [SerializeField] AudioClip eatingSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            if (player.currentHp < player.maxHP)
            {
                player.currentHp += player.maxHP / 2f;
                if (player.currentHp> player.maxHP)
                {
                    player.currentHp = player.maxHP;
                }
            }
            player.healthBar.SetHealth(player.currentHp);
            AudioSource.PlayClipAtPoint(eatingSound, transform.position);
            Destroy(gameObject);
        }
    }
}
