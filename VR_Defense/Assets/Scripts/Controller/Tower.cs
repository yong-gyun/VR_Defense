using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float HP { get { return _hp; } }
    float _hp = 100;
    bool isHit;
    GameObject[] blastLocations = new GameObject[3];

    private void Start()
    {
        for(int i = 0; i < blastLocations.Length; i++)
        {
            blastLocations[i] = Util.FindChild(gameObject, $"BlastLocation_{i + 1}", true);
        }
    }

    public void OnDamaged(float damage)
    {
        if (isHit)
            return;
       _hp -= damage;

        Debug.Log($"On damaged tower HP : {_hp}");
        if(_hp <= 0)
        {
            StartCoroutine(OnDie());
        }
    }

    IEnumerator OnDie()
    {
        if (isHit == true)
            yield break;
        
        _hp = 0;
        isHit = true;

        for (int j = 0; j < blastLocations.Length; j++)
        {
            GameObject go = Managers.Resource.Instantiate("Effect/ExplosionParticle", blastLocations[j].transform.position, Quaternion.identity);
            Managers.Resource.Destroy(go, 3f);
            yield return new WaitForSeconds(0.25f);
        }

        for (int i = 1; i < 3; i++)
        {
            GameObject smoke = Managers.Resource.Instantiate("Effect/SmokeParticle", blastLocations[2].transform.position, Quaternion.identity);
            smoke.transform.localScale = new Vector3(60, 60, 60);
        }

        yield return new WaitForSeconds(1f);
    }
}
