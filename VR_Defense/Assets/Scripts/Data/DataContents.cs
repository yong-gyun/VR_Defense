using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<T>
{
    List<T> MakeList();
}

public class MobStat
{
    public float hp;
    public float damage;
}

public class MosStatData : ILoader<MobStat>
{
    public List<MobStat> MobStat = new List<MobStat>();

    public List<MobStat> MakeList()
    {
        return MobStat;
    }
}
