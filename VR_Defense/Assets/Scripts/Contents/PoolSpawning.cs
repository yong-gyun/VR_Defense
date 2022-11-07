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
    int _currentWave = 1;

    IEnumerator waveCorutine;

    enum Wave
    {
        First,
        Second,
        Third,
        Boss,
    }

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

    MobBase GetMob(Define.MobType type, int idx = 0)
    {
        MobBase mob = null;

        switch (type)
        {
            case Define.MobType.Wolf:
                 mob = Managers.Pool.Pop(_wolf, spawnPoint[idx].position).GetComponent<MobBase>();
                break;
            case Define.MobType.InfernoDragon:
                mob = Managers.Pool.Pop(_inferno, spawnPoint[idx].position).GetComponent<MobBase>();
                break;
            case Define.MobType.Crab:
                mob = Managers.Pool.Pop(_crab, spawnPoint[idx].position).GetComponent<MobBase>();
                break;
        }

        mobCount++;
        mob.Init(_currentWave);
        mob._hpBar.OnUpdateUI(mob.MaxHP);
        return mob;
    }

    public void StopWave()
    {
        StopCoroutine(waveCorutine);
        gameObject.SetActive(false);
    }

    IEnumerator FirstWave()
    {
        waveCorutine = FirstWave();
        Managers.UI.ShowWorldSpaceUI<UI_Wave>().Init("Wave 1");
        yield return new WaitForSeconds(3f);

        float delay = 10;
        WaitForSeconds wait = new WaitForSeconds(delay);
        
        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.Crab, 3);
        GetMob(Define.MobType.Crab, 0);
        yield return wait;

        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Crab, 2);
        GetMob(Define.MobType.Crab, 3);
        yield return wait;

        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Crab, 2);
        GetMob(Define.MobType.Crab, 3);
        yield return wait;

        GetMob(Define.MobType.Wolf, 4);
        GetMob(Define.MobType.Wolf, 5);
        GetMob(Define.MobType.Wolf, 0);
        yield return wait;

        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        GetMob(Define.MobType.Crab, 4);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.Crab, 4);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.InfernoDragon, 2);
        GetMob(Define.MobType.Crab, 0);
        yield return wait;

        while (mobCount > 0)
            yield return null;

        Managers.Game.Tower.Heal(Managers.Game.Tower.MaxHP / 4);
        waveCorutine = SecondWave();
        yield return new WaitForSeconds(3f);
        StartCoroutine(waveCorutine);
    }

    IEnumerator SecondWave()
    {
        _currentWave++;
        Managers.UI.ShowWorldSpaceUI<UI_Wave>().Init("Wave 2");
        yield return new WaitForSeconds(3f);

        float delay = 8f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.Crab, 0);
        yield return wait;          
                                    
        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Crab, 3);
        yield return wait;          
                                    
        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3); 
        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.Crab, 5);
        yield return wait;          
                                    
        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.InfernoDragon, 4);
        GetMob(Define.MobType.Wolf, 5);
        GetMob(Define.MobType.Crab, 0);
        yield return wait;          
                                    
                                    
        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Crab, 5);
        GetMob(Define.MobType.Crab, 0);
        yield return wait;          
                                    
        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Crab, 5);
        GetMob(Define.MobType.InfernoDragon, 4);
        GetMob(Define.MobType.InfernoDragon, 2);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Crab, 3);
        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.Crab, 5);
        yield return wait;

        Managers.Game.Tower.Heal(Managers.Game.Tower.MaxHP / 2);
        waveCorutine = ThirdWave();
        yield return new WaitForSeconds(3f);
        StartCoroutine(waveCorutine);
    }

    
    IEnumerator ThirdWave()
    {
        waveCorutine = FirstWave();
        Managers.UI.ShowWorldSpaceUI<UI_Wave>().Init("Wave 3");
        yield return new WaitForSeconds(3f);

        float delay = 6;
        WaitForSeconds wait = new WaitForSeconds(delay);

        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.Crab, 3);
        GetMob(Define.MobType.Crab, 0);
        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        yield return wait;

        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Crab, 2);
        GetMob(Define.MobType.Crab, 3);
        GetMob(Define.MobType.InfernoDragon, 4);
        GetMob(Define.MobType.InfernoDragon, 5);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 4);
        GetMob(Define.MobType.InfernoDragon, 5);
        GetMob(Define.MobType.InfernoDragon, 0);
        yield return wait;

        GetMob(Define.MobType.Crab, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        GetMob(Define.MobType.Crab, 4);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.Crab, 4);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.Crab, 0);
        yield return wait;

        while (mobCount > 0)
            yield return null;

        Managers.Game.Tower.Heal(Managers.Game.Tower.MaxHP);
        yield return new WaitForSeconds(3f);
        StartCoroutine(waveCorutine);
    }

    IEnumerator LastWave()
    {
        waveCorutine = FirstWave();
        Managers.UI.ShowWorldSpaceUI<UI_Wave>().Init("Last wave");
        yield return new WaitForSeconds(3f);

        float delay = 3;
        WaitForSeconds wait = new WaitForSeconds(delay);

        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.Wolf, 3);
        GetMob(Define.MobType.Crab, 0);
        GetMob(Define.MobType.InfernoDragon, 1);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        GetMob(Define.MobType.Wolf, 2);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 4);
        GetMob(Define.MobType.InfernoDragon, 5);
        GetMob(Define.MobType.Wolf, 0);
        yield return wait;
        

        GetMob(Define.MobType.InfernoDragon, 1);
        GetMob(Define.MobType.InfernoDragon, 2);
        GetMob(Define.MobType.InfernoDragon, 4);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 1);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.InfernoDragon, 4);
        yield return wait;
        
        Managers.Resource.Instantiate("Character/Mob/Boss", spawnPoint[0].position, Quaternion.identity);
        mobCount++;

        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.InfernoDragon, 0);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 1);
        GetMob(Define.MobType.InfernoDragon, 3);
        GetMob(Define.MobType.InfernoDragon, 4);
        yield return wait;

        GetMob(Define.MobType.Crab, 4);
        GetMob(Define.MobType.Wolf, 3);
        GetMob(Define.MobType.Crab, 0);
        GetMob(Define.MobType.InfernoDragon, 1);
        yield return wait;

        GetMob(Define.MobType.Wolf, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        GetMob(Define.MobType.Wolf, 2);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 1);
        GetMob(Define.MobType.Wolf, 2);
        GetMob(Define.MobType.Wolf, 3);
        yield return wait;

        GetMob(Define.MobType.InfernoDragon, 4);
        GetMob(Define.MobType.InfernoDragon, 5);
        GetMob(Define.MobType.Wolf, 0);
        yield return wait;

        while (mobCount > 0)
            yield return null;

        yield return new WaitForSeconds(2f);
        Managers.Sound.PlayBGM(Define.BGM.Clear);
        Managers.Game.Over();
        
    }
}
