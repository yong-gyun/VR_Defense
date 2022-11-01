using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float _damage;
    private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
            other.GetComponent<Tower>().OnDamaged(_damage);
    }

    public void Init(float damage)
    {
        _damage = damage;
    }
}
