using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoom : BoomBase
{
    float damage = 40;

    protected override void OnExplosion<T>(T obj)
    {
        obj.OnDamaged(damage);
        GameObject go = Managers.Resource.Instantiate("Effect/DamageBoom");
        Managers.Resource.Destroy(go);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Groound"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, targetLyaer);

            if (colliders.Length == 0)
                return;

            for (int i = 0; i < colliders.Length; i++)
            {
                MobBase mob = colliders[i].transform.GetComponent<MobBase>();
                OnExplosion<MobBase>(mob);
            }
        }
    }
}
