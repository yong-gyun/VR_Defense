using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Transform[] _explosionPoints = new Transform[6];
    [SerializeField] List<MobBase> mobs = new List<MobBase>();

    float _damage = 40;
    float _slowTime = 6;
    float _stunTime = 4;
    float _coolTime = 15;

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
            GameObject go = Managers.Resource.Instantiate("Effect/SlowParticle", mob.transform);

            Managers.Resource.Destroy(go, _slowTime);
            
        }
        yield return new WaitForSeconds(_slowTime);

        foreach (MobBase mob in mobs)
        {
            mob._agent.speed = mob.MoveSpeed;
        }
        
    }

    IEnumerator OnStunBomb()
    {
        foreach (MobBase mob in mobs)
        {
            mob.OnStun();
            GameObject go = Managers.Resource.Instantiate("Effect/StunParticle", mob.transform);
            Managers.Resource.Destroy(go, _stunTime);
        }

        yield return new WaitForSeconds(_stunTime);
        
        foreach (MobBase mob in mobs)
        {
            mob._agent.enabled = true;
            mob.State = Define.State.Move;
        }

    }

    IEnumerator ExplosionEffect(Define.BombType type)
    {
        Debug.Log($"Effect {type}Explosion");

        Define.SoundEffect bombType = Define.SoundEffect.Damage;

        switch(type)
        {
            case Define.BombType.Damage:
                bombType = Define.SoundEffect.Damage;
                break;
            case Define.BombType.Stun:
                bombType = Define.SoundEffect.Stun;
                break;
            case Define.BombType.Slow:
                bombType = Define.SoundEffect.Slow;
                break;
        }

        for(int i = 0; i < _explosionPoints.Length; i++)
        {
            GameObject go = Managers.Resource.Instantiate($"Effect/{type}Explosion", _explosionPoints[i].position, Quaternion.identity);
            Managers.Sound.PlaySoundEffect(bombType);
            Managers.Resource.Destroy(go, 1f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
