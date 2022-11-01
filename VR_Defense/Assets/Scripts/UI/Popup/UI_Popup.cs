using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject);
    }

    public virtual void ShowUIPopup()
    {
        Managers.UI.ShowUIPopup<UI_Popup>();
    }
}
