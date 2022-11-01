using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Setting : UI_Popup
{
    enum Sliders
    {
        BgmSlider,
        SfxSlider
    }

    public override void Init()
    {
        base.Init();

        Bind<Slider>(typeof(Sliders));
    }

    void OnDragBgmSlider(PointerEventData evtData)
    {

    }

    void OnDragSfxSlider(PointerEventData evtData)
    {

    }
}
