using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MobBase
{
    protected override void Start()
    {
        base.Start();

        Init(50, 5, 3, 5);
        _type = Define.MobType.Crab;
    }

    public override void OnDamaged(float damage)
    {
        damage *= (7 / 10);
        base.OnDamaged(damage);
    } 
}