using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : SceneBase
{
    public override void Init()
    {
        base.Init();

        Managers.Game.CurrentGold = 0;
        Managers.Game.CurrentScore = 0;

        //Managers.UI.ShowUIScene<UI_Countdown>();
    }
}
