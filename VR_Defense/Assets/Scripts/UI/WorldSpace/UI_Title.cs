using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Title : UI_WorldSpace
{
    enum Buttons
    {
        StartButton,
        OptionButton
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.StartButton).gameObject.AddUIEvent(OnClickStartButton, Define.UIEvent.Click);
        GetButton((int)Buttons.OptionButton).gameObject.AddUIEvent(OnClickSettingButton, Define.UIEvent.Click);
    }

    void OnClickStartButton(PointerEventData evtData)
    {
        Managers.Scene.Load(Define.Scene.Game);
    }

    void OnClickSettingButton(PointerEventData evtData)
    {
        //Managers.UI.ShowUIPopup<>();
    }
}
