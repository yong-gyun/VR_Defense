using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<string, int> User = new Dictionary<string, int>();
    public Dictionary<Define.MobType, MobStat> mobStat { get; private set; } = new Dictionary<Define.MobType, MobStat>();
    
    public void Init()
    {
        mobStat = LoadJson<MosStatData, Define.MobType, MobStat>("Data/Stat").MakeDic();
    }

    Loader LoadJson<Loader, TKey, TValue>(string path) where Loader : ILoader<TKey, TValue>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}