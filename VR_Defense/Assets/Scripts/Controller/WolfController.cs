using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MobBase
{
    protected override void Start()
    {
        base.Start();

        Init(50, 10, 5, 12);
        _type = Define.MobType.Wolf;
        _myGold = 2;
        _myScore = 15;
    }
}