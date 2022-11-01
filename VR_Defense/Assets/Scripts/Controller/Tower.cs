using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float HP { get { return _hp; } }
    float _hp = 100;

    public void OnDamaged(float damage)
    {
        _hp -= damage;

        if(_hp <= 0)
        {
            _hp = 0;
            Managers.Game.Over();
        }
    }
}
