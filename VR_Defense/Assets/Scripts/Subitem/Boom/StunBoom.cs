using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBoom : BoomBase
{
    private float _duration = 3f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnExplosion<T>(T obj)
    {

    }
}
