using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Crosshair : UI_Base
{
    enum Images
    {
        Crosshair
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));
    }

    private void Update()
    {
        ARAVRInput.DrawCrosshair(gameObject.transform);
    }
}
