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
        Managers.Game.Player.transform.position = new Vector3(1, 13, 2.5f);
        Managers.Game.Player.transform.rotation = Quaternion.identity;

        //Managers.UI.ShowUIScene<UI_Countdown>();
    }
}
