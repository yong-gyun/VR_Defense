using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WorldSpace : UI_Base
{
    protected virtual void Start()
    {
        Init();
    }

    public override void Init()
    {
        gameObject.AddComponent<OVRRaycaster>().pointer = Managers.Input.LaserPointer.gameObject;
        Canvas canvas = Util.GetOrAddComponent<Canvas>(gameObject);
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;
    }
}
