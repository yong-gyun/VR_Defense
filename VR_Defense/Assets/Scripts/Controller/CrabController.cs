using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MobBase
{
    private int shildCount = 3;

    protected override void Start()
    {
        base.Start();

        Init(50, 8, 3, 5, Define.MobType.Crab);
    }

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