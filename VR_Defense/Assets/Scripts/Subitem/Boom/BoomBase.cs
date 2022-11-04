using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoomBase : MonoBehaviour
{
    protected float _radius;
    protected LayerMask targetLyaer;

    protected virtual void Start()
    {
        Init();
    }

    public virtual void Init(float radius = 4)
    {
        targetLyaer = 1 << LayerMask.NameToLayer("Mob");
        _radius = radius;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Groound"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, targetLyaer);

            if (colliders.Length == 0)
                return;

            for (int i = 0; i < colliders.Length; i++)
            {
                MobBase mob = colliders[i].transform.GetComponent<MobBase>();

                if (mob.State != Define.State.Ailment)
                    OnExplosion<MobBase>(mob);
            }
        }
    }

    protected abstract void OnExplosion<T>(T obj) where T : MobBase;
}
