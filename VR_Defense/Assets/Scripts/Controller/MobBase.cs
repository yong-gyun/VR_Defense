using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobBase : MonoBehaviour
{
    public Define.MobType Type { get { return _type; } }
    public float MaxHP { get { return _maxHP; } }

    public NavMeshAgent _agent { get; set; }
    protected Animator _animator;
    protected Transform _target;
    protected GameObject _hpHar;
    protected Define.State _state;
    protected Define.MobType _type;
    protected float _damage;
    protected float _maxHP;
    protected float _hp;
    protected float _attackRange;
    protected float _speed;
    
    public Transform Target
    {
        get
        {
            if (_target == null)
                _target = Managers.Game.Tower.transform;

            return _target;
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
            _state = value;

            switch (_state)
            {
                case Define.State.Move:
                    Debug.Log("Move");
                    _animator.CrossFade("Move", 0.1f);
                    break;
                case Define.State.Attack:
                    Debug.Log("Attack");
                    _animator.CrossFade("Attack", 0.1f, -1, 0);
                    break;
                case Define.State.Hit:
                    Debug.Log("Hit");
                    _animator.CrossFade("Hit", 0.1f);
                    break;
                case Define.State.Die:
                    Debug.Log("Die");
                    _animator.CrossFade("Die", 0.1f);
                    break;
            }
        }
    }

    protected virtual void Start()
    {
        _animator = Util.GetOrAddComponent<Animator>(gameObject);
        _agent = Util.GetOrAddComponent<NavMeshAgent>(gameObject);
    }

    protected virtual void Update()
    {
        switch(State)
        {
            case Define.State.Move:
                UpdateMove();
                break;
            case Define.State.Attack:
                UpdateAttack();
                break;
        }
    }

    public virtual void Init(float hp, float damage, float speed, float attackRange, Define.MobType type)
    {
        _maxHP = hp;
        _hp = _maxHP;
        _damage = damage;
        _attackRange = attackRange;
        _speed = speed;
        _state = Define.State.Move;
        _type = type;
        _agent.speed = _speed;
    }

    protected virtual void UpdateMove()
    {
        Debug.Log("Update Move");

        Vector3 dir = Target.position - transform.position;
        Quaternion qua = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, qua, 20 * Time.deltaTime);
        _agent.SetDestination(Target.position);

        if ((Target.position - transform.position).magnitude <= _attackRange)
        {
            State = Define.State.Attack;
            _agent.SetDestination(transform.position);
            return;
        }
    }

    protected virtual void UpdateAttack()
    {
        Debug.Log("Update Attack");

        if ((Target.position - transform.position).magnitude > _attackRange)
        {
            State = Define.State.Move;
            return;
        }
    }

    public virtual void OnDamaged(float damage)
    {
        _hp -= damage;
        State = Define.State.Hit;
        //@Todo make knock back

        if (_hp <= 0)
        {
            State = Define.State.Die;
        }
    }

    public virtual void OnHit()
    {
        if (_state == Define.State.Die)
            return;

        if ((Target.position - transform.position).magnitude > _attackRange)
        {
            State = Define.State.Move;
        }
        else
        {
            State = Define.State.Attack;
        }
    }

    public virtual void OnAttack() 
    {
        Debug.Log("OnAttack");
        Managers.Game.Tower.OnDamaged(_damage); 
    }

    public virtual void OnDie()
    {
        Debug.Log("Die");
    }
}
