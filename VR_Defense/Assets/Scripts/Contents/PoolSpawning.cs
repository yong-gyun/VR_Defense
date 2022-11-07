using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawning : MonoBehaviour
{
    Transform[] spawnPoint = new Transform[6];

    GameObject _wolf;
    GameObject _inferno;
    GameObject _crab;
    public static int mobCount = 0;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        for(int i = 0; i < spawnPoint.Length; i++)
        {
            spawnPoint[i] = transform.Find($"SpawnPoint_{i + 1}");
        }

        _wolf = Managers.Resource.Load<GameObject>("Prefabs/Character/Wolf");
        _inferno = Managers.Resource.Load<GameObject>("Prefabs/Character/Inferno");
        _crab = Managers.Resource.Load<GameObject>("Prefabs/Character/Crab");

        StartCoroutine(FirstWave());
    }

    IEnumerator FirstWave()
    {
        Managers.Pool.Pop(_wolf, spawnPoint[0].position).GetComponent<MobBase>();
        Managers.Pool.Pop(_wolf, spawnPoint[1].position);
        Managers.Pool.Pop(_wolf, spawnPoint[2].position);
        yield return new WaitForSeconds(5f);
        
        Managers.Pool.Pop(_wolf, spawnPoint[3].position);
        Managers.Pool.Pop(_wolf, spawnPoint[4].position);
        Managers.Pool.Pop(_wolf, spawnPoint[5].position);
        yield return new WaitForSeconds(5f);

        Managers.Pool.Pop(_wolf, spawnPoint[0].position);
        Managers.Pool.Pop(_wolf, spawnPoint[1].position);
        Managers.Pool.Pop(_wolf, spawnPoint[2].position);
        yield return new WaitForSeconds(5f);

        Managers.Pool.Pop(_inferno, spawnPoint[0].position);
        Managers.Pool.Pop(_inferno, spawnPoint[1].position);
        Managers.Pool.Pop(_inferno, spawnPoint[2].position);
        yield return new WaitForSeconds(5f);

        Managers.Pool.Pop(_wolf, spawnPoint[0].position);
        Managers.Pool.Pop(_wolf, spawnPoint[0].position);
        Managers.Pool.Pop(_wolf, spawnPoint[0].position);
        yield return new WaitForSeconds(5f);

        while (mobCount > 0)
            yield return null;
    }

    public void SecondWave()
    {

    }

    public void ThirdWave()
    {

    }

    public void FourthWave()
    {

    }

    public void BossWave()
    {

    }
}
