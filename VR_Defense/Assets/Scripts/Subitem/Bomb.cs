using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Transform[] _explosionPoints = new Transform[6];
    List<MobBase> mobs = new List<MobBase>();

    float _damage = 40;
    float _slowTime = 4;
    float _stunTime = 2;
    float _coolTime = 10;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        for(int i = 0; i < _explosionPoints.Length; i++)
            _explosionPoints[i] = transform.Find($"ExplosionPoint_{i + 1}");
    }

    public void OnExplosion(Define.BombType type)
    {
        foreach(Poolable poolable in Managers.Pool.poolableList)
        {
            if (poolable.IsUsing == true)
                mobs.Add(poolable.GetComponent<MobBase>());
        }

        switch(type)
        {
            case Define.BombType.Damage:
                OnDamageBomb();
                StartCoroutine(ExplosionEffect(Define.BombType.Damage));
                break;
            case Define.BombType.Slow:
                StartCoroutine(OnSlowBomb());
                StartCoroutine(ExplosionEffect(Define.BombType.Slow));
                break;
            case Define.BombType.Stun:
                StartCoroutine(OnStunBomb());
                StartCoroutine(ExplosionEffect(Define.BombType.Stun));
                break;
        }
    }

    void OnDamageBomb()
    {
        foreach(MobBase mob in mobs)
            mob.OnDamaged(_damage);
    }

    IEnumerator OnSlowBomb()
    {
        foreach (MobBase mob in mobs)
        {
            float tmpSpeed = mob.MoveSpeed;
            mob._agent.speed = tmpSpeed / 2;
            yield return new WaitForSeconds(_slowTime);
            mob._agent.speed = tmpSpeed;
        }
    }

    IEnumerator OnStunBomb()
    {
        foreach (MobBase mob in mobs)
        {
            mob.OnStun(_stunTime);
            yield return new WaitForSeconds(_stunTime);
            mob.State = Define.State.Move;
        }
    }

    IEnumerator ExplosionEffect(Define.BombType type)
    {
        Debug.Log($"Effect {type}Explosion");

        for(int i = 0; i < _explosionPoints.Length; i++)
        {
            GameObject go = Managers.Resource.Instantiate($"Effect/{type}Explosion", _explosionPoints[i].position, Quaternion.identity);
            Managers.Resource.Destroy(go, 1f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
