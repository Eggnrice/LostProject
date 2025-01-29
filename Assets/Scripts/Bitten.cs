using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitten : Enemy 
{
    float waitTimer = 2f;

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Destroy(gameObject);
    }

}
