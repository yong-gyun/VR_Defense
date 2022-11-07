using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBase : MonoBehaviour
{
    protected virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        UnityEngine.Object obj = GameObject.Find("UIHelpers");
        OVRInputModule inputModule = null;
        
        if (obj == null)
        {
            GameObject go = Managers.Resource.Instantiate("UI/EventSystem");
            go.name = "@EventSystem"; 
            Managers.Resource.Instantiate("UI/UIHelpers").name = "@UIHelpers";
            inputModule = go.GetComponent<OVRInputModule>();
        }

        inputModule.rayTransform = GameObject.Find("CenterEyeAnchor").transform;
        inputModule.m_Cursor = Managers.Input.LaserPointer;
    }
}
