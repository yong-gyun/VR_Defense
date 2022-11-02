using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrnoController : MobBase
{
    protected override void Start()
    {
        base.Start();
        Init(40, 12, 7, 14, Define.MobType.InfernoDragon);
    }

    public override void OnAttack()
    {
        Debug.Log("Attack");
        //Managers.Resource.Instantiate("Item/Fireball").GetOrAddComponent<Fireball>().Init(_damage);
    }
}
