using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawning : MonoBehaviour
{
    Transform[] spawnPoint = new Transform[6];

    GameObject _wolfOriginal;
    GameObject _infernoOriginal;
    GameObject _crabOriginal;

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

        _wolfOriginal = Managers.Resource.Load<GameObject>("Prefabs/Character/Wolf");
        _infernoOriginal = Managers.Resource.Load<GameObject>("Prefabs/Character/Inferno");
        _crabOriginal = Managers.Resource.Load<GameObject>("Prefabs/Character/Crab");

        FirstWave();
    }

    public void FirstWave()
    {
        Managers.Pool.Pop(_wolfOriginal, spawnPoint[0].position);
        Managers.Pool.Pop(_infernoOriginal, spawnPoint[1].position);
        Managers.Pool.Pop(_crabOriginal, spawnPoint[2].position);
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
