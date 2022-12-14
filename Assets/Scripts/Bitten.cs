using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitten : Enemy 
{
    float waitTimer = 2f;

    protected override void Update()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0)
        {
        
            base.Update();

        }
    }
}
