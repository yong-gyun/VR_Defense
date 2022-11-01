using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MobBase
{
    protected override void Start()
    {
        base.Start();

        Init(50, 10, 8, 10, Define.MobType.Woolf);
    }
}
