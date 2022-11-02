using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _firePos = null;
 
    //private int _magazine = 0;
    public float _shotDelay = 0.8f;
    public float _damage;
    private float _reloadDelay = 1;
    private bool isShooting;
    //private const int MAGAZINE_COUNT = 8;

    public void Init(float damage)
    {
        GameObject gun = Managers.Resource.Instantiate("Item/Gun", ARAVRInput.RHandPosition, Quaternion.identity, ARAVRInput.RHand);
        gun.transform.localPosition = new Vector3(0.3f, -0.5f, 1);
        Managers.UI.MakeWorldSpaceUI<UI_Crosshair>(Managers.UI.Root.transform);
        _firePos = Util.FindChild(gun, "FirePos", true).transform;

        _damage = damage;
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

        Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
        RaycastHit hit;

        GameObject shotParticle = Managers.Resource.Instantiate($"Effect/ShotParticle", _firePos.position, Quaternion.Euler(-90, 0, 0));

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.CompareTag("Mob"))
            {
                hit.transform.GetComponent<MobBase>().OnDamaged(_damage);
            }

            GameObject hitParticle = Managers.Resource.Instantiate("Effect/HitParticle", hit.point, Quaternion.identity);
            Debug.Log("Hit : " + hit.transform.name);
        }

        isShooting = true;
        yield return new WaitForSeconds(_shotDelay);
        isShooting = false;
    }
}
