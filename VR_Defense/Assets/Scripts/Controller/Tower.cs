using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float HP { get { return _hp; } }
    float _hp = 100;
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
        _hp -= damage;

        Debug.Log($"On damaged tower HP : {_hp}");
        if(_hp <= 0)
        {
            StartCoroutine(OnDie());
        }
    }

    IEnumerator OnDie()
    {
        if (_hp == 0)
            yield break;

        _hp = 0;
    
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < blastLocations.Length; j++)
            {
                GameObject go = Managers.Resource.Instantiate("Effect/ExplosionParticle", blastLocations[j].transform.position, Quaternion.identity);
                Managers.Resource.Destroy(go, 3f);
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(0.5f);
        }

        Managers.Game.Over();
    }
}
