
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MobBase : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _animator;
    protected Transform _lockTarget;
    protected Rigidbody _rigidbody;
    protected Define.State _state;
    protected float _damage;
    protected float _hp;
    protected float _attackRange;
    
    public Transform Target
    {
        get
        {
            if(_lockTarget == null)
                _lockTarget = GameObject.Find("@Target").transform;

            return _lockTarget;
        }
    }

    public virtual Define.State State
    {
        get
        {
            return _state;
        }
        set
        {
            switch (_state)
            {
                case Define.State.Move:
                    _animator.CrossFade("Move", 0.1f);
                    break;
                case Define.State.Attack:
                    _animator.CrossFade("Attack", 0.1f);
                    break;
                case Define.State.Hit:
                    _animator.CrossFade("Hit", 0.1f);
                    break;
                case Define.State.Die:
                    _animator.CrossFade("Die", 0.1f);
                    break;
            }
        }
    }

    protected virtual void Start()
    {
        _animator = Util.GetOrAddComponent<Animator>(gameObject);
        _agent = Util.GetOrAddComponent<NavMeshAgent>(gameObject);
        _rigidbody = Util.GetOrAddComponent<Rigidbody>(gameObject);
    }

    protected virtual void Update()
    {
        switch(_state)
        {
            case Define.State.Move:
                UpdateMove();
                break;
            case Define.State.Attack:
                UpdateAttack();
                break;
            case Define.State.Die:
                UpdateDie();
                break;
        }
    }

    public void Init(float hp, float damage, float attackRange)
    {
        _hp = hp;
        _damage = damage;
        _attackRange = attackRange;
        _state = Define.State.Move;
    }

    protected virtual void UpdateMove()
    {
        if((Target.position - transform.position).magnitude <= _attackRange)
        {
            UpdateAttack();
            return;
        }

        _agent.Move(_lockTarget.position);
        _state = Define.State.Move;
    }

    protected virtual void UpdateAttack()
    {
        _state = Define.State.Attack;
    }


    protected virtual void UpdateDie()
    {
        Managers.Resource.Instantiate("Mob/DieEffect");
        Destroy(gameObject);
    }

    public void OnDamaged(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            _state = Define.State.Die;
        }
    }

    public void OnAttack()
    {
        Managers.Game.Tower.OnDamaged(_damage);
    }
}
