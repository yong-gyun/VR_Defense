using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Over : UI_Scene
{
    enum InputFields
    {
        UserNameField,
    }

    enum Buttons
    {
        TitleButton,
        ConfirmButton
    }

    enum Texts
    {
        ScoreText
    }

    public override void Init()
    {
        base.Init();

        Bind<InputField>(typeof(InputFields));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetText((int)Texts.ScoreText).text = $"{Managers.Game.CurrentScore}";

        if(Managers.Game.OverType == Define.EndGame.Clear)
        {
            Get<InputField>((int) InputFields.UserNameField).gameObject.SetActive(true);
            GetButton((int)Buttons.ConfirmButton).gameObject.SetActive(true);
        }
    }

    void InputCheck()
    {
        InputField inputField = Get<InputField>((int)InputFields.UserNameField);
        if (string.IsNullOrEmpty(inputField.text))
            return;


    }
}