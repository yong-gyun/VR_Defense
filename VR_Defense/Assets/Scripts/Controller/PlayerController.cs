using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _firePos;

    public float damage { get; set; } = 8;
    public float fireSpeed { get; set; } = 0.8f;
    private bool isFire = false;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RHand))
            StartCoroutine(Fire());
    }
    
    public void Init()
    {
        GameObject gun = Managers.Resource.Instantiate("Item/Gun", ARAVRInput.RHandPosition, Quaternion.identity, ARAVRInput.RHand);
        gun.transform.localPosition = new Vector3(0.3f, -0.5f, 0.5f);
        Managers.UI.MakeWorldSpaceUI<UI_Crosshair>(Managers.UI.Root.transform);
        _firePos = Util.FindChild(gun, "FirePos", true).transform;

    }


    IEnumerator Fire()
    {
        if (isFire == true)
            yield break;

        Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
        RaycastHit hit;

        GameObject shotParticle = Managers.Resource.Instantiate($"Effect/ShotParticle", _firePos.position, Quaternion.Euler(-90, 0, 0));

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.CompareTag("Mob"))
            {
                hit.transform.GetComponent<MobBase>().OnDamaged(damage);
            }

            GameObject hitParticle = Managers.Resource.Instantiate("Effect/HitParticle", hit.point, Quaternion.identity);
        }

        isFire = true;
        yield return new WaitForSeconds(fireSpeed);
        isFire = false;
    }
}