using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MobBase
{
    private int shildCount = 3;

    public override void OnDamaged(float damage)
    {
        if(shildCount > 0)
        {
            shildCount--;
            return;
        }

        base.OnDamaged(damage);
    }
}