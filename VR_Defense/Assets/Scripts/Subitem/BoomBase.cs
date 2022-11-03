using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoomBase : MonoBehaviour
{
    protected float _radius;
    protected LayerMask targetLyaer;

    public virtual void Init()
    {
        targetLyaer = 1 << LayerMask.NameToLayer("Mob");
    }

    public virtual void OnBoom()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, targetLyaer);
        OnExplosion(colliders);
    }

    public abstract void OnExplosion(Collider[] colliders);
}
