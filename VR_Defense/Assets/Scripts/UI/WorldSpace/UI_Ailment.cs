using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ailment : UI_Base
{
    public enum Ailment
    {
        Stun,
        Slow
    }

    enum Images
    {
        AilmentImage
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
    }

    public void Init(Ailment type)
    {
        GetImage((int)Images.AilmentImage).sprite = Managers.Resource.Load<Sprite>($"Sprites/{type}");
    }

    
}
