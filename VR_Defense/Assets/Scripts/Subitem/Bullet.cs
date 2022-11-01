using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage = 0;
    private float _moveSpeed = 15;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mob"))
        {
            other.GetComponent<MobBase>().OnDamaged(_damage);
        }
    }
}
