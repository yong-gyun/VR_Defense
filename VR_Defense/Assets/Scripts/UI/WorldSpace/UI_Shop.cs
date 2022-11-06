using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : UI_Base
{
    enum Buttons
    {
        BuyDamageBoomButton,
        BuySlowBoomButton,
        BuyStunBoomButton,
        ShotSpeedImage,
        DamageUpdradeButton,
        FireSpeedUpdradeButton,
    }

    enum Images
    {
        DamageButtonPanel,
        StunButtonPanel,
        SlowButtonPanel
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

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        bomb = FindObjectOfType<Bomb>();
    }

    void OnBuyDamageBoom()
    {
        if (Managers.Game.CurrentGold < _damageBoomPrice || isBuyDamageBomb == true)
            return;

        Managers.Game.CurrentGold -= _damageBoomPrice; 
        bomb.OnExplosion(Define.BombType.Damage);
    }

    void OnBuySlowBoom()
    {
        if (Managers.Game.CurrentGold < _slowBoomPrice || isBuySlowBomb)
            return;

        Managers.Game.CurrentGold -= _slowBoomPrice;
        bomb.OnExplosion(Define.BombType.Slow);
    }

    void OnBuyStunBoom()
    {
        if (Managers.Game.CurrentGold < _stunBoomPrice || isBuyStunBomb)
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
    }

    void UpgradeFireSpeed()
    {
        if (Managers.Game.CurrentGold < _upgradeFireSpeedPrice)
            return;

        Managers.Game.CurrentGold -= _upgradeFireSpeedPrice;
        Managers.Game.Player.fireSpeed -= _upgradeFireSpeed;
    }

    IEnumerator Cooltime(Define.BombType type)
    {
        switch(type)
        {
            case Define.BombType.Damage:
                GetImage((int)Images.DamageButtonPanel).gameObject.SetActive(true);
                isBuyDamageBomb = true;
                yield return new WaitForSeconds(_coolTime);
                GetImage((int)Images.DamageButtonPanel).gameObject.SetActive(false);
                isBuyDamageBomb = false;
                break;

            case Define.BombType.Stun:
                GetImage((int)Images.StunButtonPanel).gameObject.SetActive(true);
                isBuyStunBomb = true;
                yield return new WaitForSeconds(_coolTime);
                GetImage((int)Images.StunButtonPanel).gameObject.SetActive(false);
                isBuyStunBomb = false;
                break;

            case Define.BombType.Slow:
                GetImage((int)Images.SlowButtonPanel).gameObject.SetActive(true);
                isBuySlowBomb = true;
                yield return new WaitForSeconds(_coolTime);
                GetImage((int)Images.SlowButtonPanel).gameObject.SetActive(false);
                isBuySlowBomb = false;
                break;
        }
    }
}
