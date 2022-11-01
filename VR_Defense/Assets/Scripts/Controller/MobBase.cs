
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MobBase : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Transform _target;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Define.State _state;
    [SerializeField] protected Define.MobType _type;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _hp;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _speed;
    public Define.MobType Type { get { return _type; } }

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
                    _animator.CrossFade("Move", 0.5f);
                    break;
                case Define.State.Attack:
                    Debug.Log("Attack");
                    _animator.CrossFade("Attack", 0.1f, -1, 0);
                    break;
                case Define.State.Hit:
                    Debug.Log("Hit");
                    _animator.CrossFade("Hit", 0.5f);
                    break;
                case Define.State.Die:
                    Debug.Log("Die");
                    _animator.CrossFade("Die", 0.5f);
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
        switch(State)
        {
            case Define.State.Move:
                UpdateMove();
                break;
            case Define.State.Attack:
                UpdateAttack();
                break;
            case Define.State.Hit:
                UpdateHit();
                break;
            case Define.State.Die:
                UpdateDie();
                break;
        }
    }

    public void Init(float hp, float damage, float speed, float attackRange, Define.MobType type)
    {
        _hp = hp;
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

        if((Target.position - transform.position).magnitude <= _attackRange)
        {
            State = Define.State.Attack;
            return;
        }

        _agent.Move(_target.position * Time.deltaTime);
        State = Define.State.Move;
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

    protected virtual void UpdateHit()
    {
        Debug.Log("Update Hit");
    }

    protected virtual void UpdateDie()
    {
        Debug.Log("Update Die");
        //Managers.Resource.Instantiate("Mob/DieEffect");
    }


    public void OnDamaged(float damage)
    {
        _hp -= damage;
        State = Define.State.Hit;

        if (_hp <= 0)
        {
            _state = Define.State.Die;
        }
    }

    public void OnAttack() 
    {
        Debug.Log("OnAttack");
        Managers.Game.Tower.OnDamaged(_damage); 
    }

    public void OnDie()
    {
        Debug.Log("Die"); Managers.Resource.Destroy(gameObject); 
    }
}
