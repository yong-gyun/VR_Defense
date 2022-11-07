using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, MobStat> wolfStat { get; private set; } = new Dictionary<int, MobStat>();
    public Dictionary<int, MobStat> crabStat { get; private set; } = new Dictionary<int, MobStat>();
    public Dictionary<int, MobStat> infernoStat { get; private set; } = new Dictionary<int, MobStat>();
    
    public void Init()
    {
        wolfStat = LoadJson<MosStatData, int, MobStat>("WolfStat").MakeDic();
        crabStat = LoadJson<MosStatData, int, MobStat>("CrabStat").MakeDic();
        infernoStat = LoadJson<MosStatData, int, MobStat>("InfernoDragonStat").MakeDic();
    }

    Loader LoadJson<Loader, TKey, TValue>(string path) where Loader : ILoader<TKey, TValue>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}