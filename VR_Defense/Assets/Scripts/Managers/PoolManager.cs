using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public GameObject Root
    {
        get
        {
            if(_root == null)
            {
                GameObject go = GameObject.Find("@Pool_Root");

                if (go == null)
                    go = new GameObject { name = "@Pool_Root" };

                _root = go;
            }

            return _root;
        }
    }

    GameObject _root = null;

    Dictionary<Type, Queue<MobBase>> _mobPool = new Dictionary<Type, Queue<MobBase>>();

    public void Init()
    {
        
    }

    public Queue<T> CreateQueue<T>(T mob, int Count = 5)
    {
        Queue<T> myQueue = new Queue<T>();

        for(int i = 0 ; i < Count; i++)
        {
            GameObject go = Managers.Resource.Instantiate($"Character/Monster/{typeof(T).Name}", Root.transform); 
        }

        return myQueue;
    }
}
