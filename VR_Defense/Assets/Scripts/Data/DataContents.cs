using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<TKey, TValue>
{
    Dictionary<TKey, TValue> MakeDic();
}

public class MobStat
{
    public float hp;
    public float damage;
    public float speed;
    public float attackRange;
}

public class MosStatData : ILoader<Define.MobType, MobStat>
{
    public List<MobStat> stat = new List<MobStat>();

    public Dictionary<Define.MobType, MobStat> MakeDic()
    {
        Dictionary<Define.MobType, MobStat> myDic = new Dictionary<Define.MobType, MobStat>();

        foreach(MobStat stat in stat)
        {
            myDic.Add(stat.type, stat);
        }

        return myDic;
    }
}
