using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UI_Wave : UI_WorldSpace
{
    enum Texts
    {
        WaveText
    }

    const float duration = 5f;

    public override void Init()
    {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    public void Init(string message)
    {
        GetText((int)Texts.WaveText).text = message;
        GetText((int)Texts.WaveText).DOFade(0, duration);
    }
}