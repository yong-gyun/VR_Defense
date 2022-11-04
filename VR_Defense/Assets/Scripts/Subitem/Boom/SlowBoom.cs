using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBoom : BoomBase
{
    private float _duration = 3f;

    protected override void OnExplosion<T>(T obj)
    {

    }

    IEnumerator SlowCorutine(MobBase obj)
    {
        float tmpSpeed = obj._agent.speed;
        obj._agent.speed = tmpSpeed / 2;
        yield return new WaitForSeconds(_duration);
        obj._agent.speed = tmpSpeed;
    }
}
