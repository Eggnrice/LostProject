using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.SetTarget(transform.parent.position);
        }
        if (collision.gameObject.TryGetComponent<Crystal>(out Crystal crystal))
        {
            crystal.SetTarget(transform.parent.position);
        }
    }

}
