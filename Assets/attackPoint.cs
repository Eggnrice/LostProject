using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPoint : MonoBehaviour
{
    [SerializeField] float damage;

    private void Start()
    {
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        Debug.Log("I am hitting something");
        if (player)
        {
            player.OnDamage(damage);
            Debug.Log("I am hitting the player");

        }
        if (enemy)
        {
            return;
        }


    }

    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    Player player = collision.GetComponent<Player>();
    //    Enemy enemy = collision.GetComponent<Enemy>();
    //    Debug.Log("I am hitting something stay");
    //    if (player)
    //    {
    //        player.OnDamage(damage);

    //    }
    //    if (enemy)
    //    {
    //        return;
    //    }
    //}
  
}
