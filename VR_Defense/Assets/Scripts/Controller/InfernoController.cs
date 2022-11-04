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
        _firePos = transform.Find("FirePos");
    }

    public override void OnAttack()
    {
        Debug.Log("Attack");
        GameObject beginFireball = Managers.Resource.Instantiate("Effect/BegineFireball", _firePos.position + Vector3.forward * 0.5f, Quaternion.Euler(0, 90, 90));
        Managers.Resource.Destroy(beginFireball, 1f);
        Managers.Resource.Instantiate("Item/Fireball", _firePos.position, Quaternion.identity).GetOrAddComponent<Fireball>().Init(_damage);
    }
}

