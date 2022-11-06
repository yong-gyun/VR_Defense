using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ailment : UI_Base
{
    Sprite _stunImage;
    Sprite _slowImage;

    enum Images
    {
        AilmentImage
    }

    public override void Init()
    {
        base.Init();

        _stunImage = Managers.Resource.Load<Sprite>($"Sprites/Stun");
        _slowImage = Managers.Resource.Load<Sprite>($"Sprites/Slow");
        Bind<Image>(typeof(Images));
    }

    public void SetAilment(Define.Ailment type)
    {
        switch(type)
        {
            case Define.Ailment.Stun:
                GetImage((int)Images.AilmentImage).sprite = _stunImage;
                break;
            case Define.Ailment.Slow:
                GetImage((int)Images.AilmentImage).sprite = _slowImage;
                break;
        }
    }
}
