using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Game : UI_Popup
{
    enum Texts
    {
        TimeText,
        MagazineText,
    }

    enum Slider
    {
        HpSlider,
    }


    private int _min = 2;
    private int _sec = 0;
    WaitForSeconds _time = new WaitForSeconds(1f);

    public override void Init()
    {
        base.Init();

        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    IEnumerator Timer()
    {
        while(_min > 0 || _sec > 0)
        {
            _sec--;

            if (_sec == 0)
                _min--;

            yield return _time;
        }
    }
}