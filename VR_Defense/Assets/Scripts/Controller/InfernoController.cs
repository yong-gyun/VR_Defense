using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernoController : MobBase
{
   private Transform _firePos;

    protected override void Start()
    {
        base.Start();
        Init(40, 12, 7, 25, Define.MobType.InfernoDragon);
        _firePos = GameObject.Find("FirePos").transform;
    }

    public override void OnAttack()
    {
        Debug.Log("Attack");
        Managers.Resource.Instantiate("Effect/BegineFireball", _firePos.position + Vector3.back * 0.5f, Quaternion.Euler(0, 90, -90));
        Managers.Resource.Instantiate("Item/Fireball", _firePos.position, Quaternion.identity).GetOrAddComponent<Fireball>().Init(_damage);
    }
}
