using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : UI_WorldSpace
{
    enum Buttons
    {
        BuyDamageBoomButton,
        BuySlowBoomButton,
        BuyStunBoomButton,
        UpgradeFireSpeedButton,
        UpgradeDamageButton
    }

    enum Texts
    {
        DamageStatText,
        FireSpeedStatText
    }

    int _damageBoomPrice = 25;
    int _slowBoomPrice = 22;
    int _stunBoomPrice = 25;
    int _upgradeDamagePrice = 8;
    int _upgradeFireSpeedPrice = 5;

    float _upgradeDamage = 2;
    float _upgradeFireSpeed = 0.03f;
    float _coolTime = 5f;


    bool isBuyDamageBomb;
    bool isBuySlowBomb;
    bool isBuyStunBomb;
    Bomb bomb = null;

    public override void Init()
    {
        base.Init();

        bomb = FindObjectOfType<Bomb>();

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetButton((int)Buttons.BuyDamageBoomButton).onClick.AddListener(OnBuyDamageBoom);
        GetButton((int)Buttons.BuySlowBoomButton).onClick.AddListener(OnBuySlowBoom);
        GetButton((int)Buttons.BuyStunBoomButton).onClick.AddListener(OnBuyStunBoom);
        GetButton((int)Buttons.UpgradeDamageButton).onClick.AddListener(UpgradeDamage);
        GetButton((int)Buttons.UpgradeFireSpeedButton).onClick.AddListener(UpgradeFireSpeed);

        GetText((int)Texts.DamageStatText).text = $"{Managers.Game.Player.damage}";
        GetText((int)Texts.FireSpeedStatText).text = $"{Managers.Game.Player.fireSpeed}";
    }

    void OnBuyDamageBoom()
    {
        if (Managers.Game.CurrentGold < _damageBoomPrice)
            return;

        Managers.Game.CurrentGold -= _damageBoomPrice; 
        bomb.OnExplosion(Define.BombType.Damage);
    }

    void OnBuySlowBoom()
    {
        if (Managers.Game.CurrentGold < _slowBoomPrice)
            return;

        Managers.Game.CurrentGold -= _slowBoomPrice;
        bomb.OnExplosion(Define.BombType.Slow);
    }

    void OnBuyStunBoom()
    {
        if (Managers.Game.CurrentGold < _stunBoomPrice)
            return;

        Managers.Game.CurrentGold -= _stunBoomPrice;
        bomb.OnExplosion(Define.BombType.Stun);
    }

    void UpgradeDamage()
    {
        if (Managers.Game.CurrentGold < _upgradeDamagePrice)
            return;

        Managers.Game.CurrentGold -= _upgradeDamagePrice;
        Managers.Game.Player.damage += _upgradeDamage;
        GetText((int)Texts.DamageStatText).text = $"{Managers.Game.Player.damage}"; 
    }

    void UpgradeFireSpeed()
    {
        if (Managers.Game.CurrentGold < _upgradeFireSpeedPrice)
            return;

        Managers.Game.CurrentGold -= _upgradeFireSpeedPrice;
        Managers.Game.Player.fireSpeed -= _upgradeFireSpeed;
        GetText((int)Texts.FireSpeedStatText).text = $"{Managers.Game.Player.fireSpeed}";
    }

    IEnumerator Cooltime(Define.BombType type)
    {
        Button btn = null;

        switch (type)
        {
            case Define.BombType.Damage:
                btn = GetButton((int)Buttons.BuyDamageBoomButton);
                break;

            case Define.BombType.Stun:
                btn = GetButton((int)Buttons.BuyStunBoomButton);
                break;

            case Define.BombType.Slow:
                btn = GetButton((int)Buttons.BuySlowBoomButton);
                break;
        }

        Color color = btn.image.color;
        color.a = 0.5f;
        btn.image.color = color;
        btn.enabled = false;

        yield return new WaitForSeconds(_coolTime);
        
        btn.enabled = true;
        color.a = 1f;
        btn.image.color = color;
    }
}
