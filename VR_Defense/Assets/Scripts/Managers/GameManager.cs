using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Tower Tower
    {
        get
        {
            if(_tower == null)
            {
                GameObject go = GameObject.Find("Tower");
                
                if(go == null)
                {
                    go = Managers.Resource.Instantiate("Build/Tower");
                }

                _tower = go.GetOrAddComponent<Tower>();
            }

            return _tower;
        }
    }

    public PlayerController Player
    {
        get
        {
            if(_player == null)
            {
                GameObject go = GameObject.FindObjectOfType<PlayerController>().gameObject;

                if(go == null)
                    go = Managers.Resource.Instantiate("Character/Player");

                _player = go.GetOrAddComponent<PlayerController>();
            }

            return _player;
        }
    }
    public Define.EndGame OverType = Define.EndGame.Unknow;
    public List<MobBase> mobs { get; set; } = new List<MobBase>(); 
    public int CurrentScore { get; set; } = 0;
    public int CurrentGold { get; set; } = 0;
    Tower _tower = null;
    PlayerController _player = null;
    int _userCount = 0;

    public void Save()
    {
        PlayerPrefs.SetInt("UserCount", _userCount);        
    }

    public PlayerController GetPlayer() { return _player; }

    public void Over()
    {
        GameObject.FindObjectOfType<PoolSpawning>().StopWave(); 
        Managers.Pool.CollectPool();
        Player.transform.position = new Vector3(-1.25f, 20, -4);
        Player.transform.rotation = Quaternion.Euler(Vector3.right * 15);
        CurrentScore += CurrentGold + (int) Tower.HP;
        Managers.Resource.Destroy(Player.rightGun);
        Player.enabled = false;
        Managers.UI.CloseWorldSpaceUI<UI_Shop>();
        Managers.UI.CloseWorldSpaceUI<UI_Interface>();
        UI_Over overUI = Managers.UI.MakeWorldSpaceUI<UI_Over>(Managers.UI.Root.transform);
        overUI.transform.position = new Vector3(-1, 20, 0.5f);
        _player = null;
    }

    public void Clear()
    {
        mobs.Clear();
    }
}
