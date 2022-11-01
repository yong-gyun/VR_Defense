using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Title : UI_Popup
{
    enum Buttons
    {
        StartButton,
        SettingButton
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.StartButton).gameObject.AddUIEvent(OnClickStartButton, Define.UIEvent.Click);
        GetButton((int)Buttons.SettingButton).gameObject.AddUIEvent(OnClickSettingButton, Define.UIEvent.Click);
    }

    void OnClickStartButton(PointerEventData evtData)
    {

    }

    void OnClickSettingButton(PointerEventData evtData)
    {
        //Managers.UI.ShowUIPopup<>();
    }
}
