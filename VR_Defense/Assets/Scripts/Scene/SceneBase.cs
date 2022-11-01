using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBase : MonoBehaviour
{
    public virtual void Init()
    {
        UnityEngine.Object obj = FindObjectOfType<EventSystem>();

        if (obj == null)
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
    }
}
