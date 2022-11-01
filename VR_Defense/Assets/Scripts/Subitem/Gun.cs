using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform _firePos = null;
 
    //private int _magazine = 0;
    public float _shotDelay = 0.8f;
    public float _damage = 8;
    private float _reloadDelay = 1;
    private bool isShooting;
    //private const int MAGAZINE_COUNT = 8;

    public void Init()
    {
        GameObject gun = Managers.Resource.Instantiate("Item/Gun", ARAVRInput.RHandPosition, Quaternion.identity, ARAVRInput.RHand);
        _firePos = Util.FindChild(gun, "FirePos", true).transform;
    }

    public void OnShooting()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        if (isShooting == true)
            yield break;
        
        GameObject go = Managers.Resource.Instantiate("Item/Bullet", _firePos.position, Quaternion.Euler(ARAVRInput.RHandDirection));
        
        isShooting = true;
        yield return new WaitForSeconds(_shotDelay);
        isShooting = false;
    }

    //public void Reload()
    //{
    //    if (_gunState == State.Reload)
    //        return;
    //    _gunState = State.Reload;

    //    StartCoroutine(ReloadCoroutine());
    //}

    //IEnumerator ReloadCoroutine()
    //{
    //    float time = 0;
    //    float reloadTime = 1;

    //    while(time <= _reloadDelay)
    //    {
    //        if (reloadTime / _magazine >= time)
    //            _magazine++;

    //        time += Time.deltaTime;
    //        yield return null;
    //    }

    //    _gunState = State.Shot;
    //}
}
