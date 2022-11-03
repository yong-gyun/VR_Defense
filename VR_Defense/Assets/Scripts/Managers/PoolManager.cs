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

    Queue<WolfController> _wolfPool = new Queue<WolfController>();
    Queue<InfernoController> _infernoPool = new Queue<InfernoController>();
    Queue<CrabController> _crabPool = new Queue<CrabController>();


    public void Init()
    {
        _wolfPool = CreateQueue<WolfController>(20);
        _infernoPool = CreateQueue<InfernoController>(20);
        _crabPool = CreateQueue<CrabController>(20);
    }

    public Queue<T> CreateQueue<T>(int Count = 5) where T : MobBase
    {
        Queue<T> myQueue = new Queue<T>();

        string name = typeof(T).Name;
        int index = name.IndexOf("Controller");

        if (index > 0)
            name = name.Substring(0, index);

        for (int i = 0 ; i < Count; i++)
        {
            GameObject go = Managers.Resource.Instantiate($"Character/{name}", Root.transform);
            myQueue.Enqueue(go.GetOrAddComponent<T>());
            go.SetActive(false);
        }

        return myQueue;
    }
}
