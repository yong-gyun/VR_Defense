using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Dictionary<string, int> User = new Dictionary<string, int>();

    public Tower Tower
    {
        get
        {
            if(_tower == null)
                _tower = GameObject.FindObjectOfType<Tower>();
            
            return _tower;
        }
    }

    Tower _tower = null;
    PlayerController _player;
    int _userCount = 0;

    public void Init()
    {

    }

    public void Save()
    {
        PlayerPrefs.SetInt("UserCount", _userCount);        
    }

    public void SetScore(string name, int score)
    {
        User.Add(name, score);
        _userCount++;
    }

    public void SpawnMob(Define.MobType type)
    {

    }

    public void SpawnPlayer()
    {
        GameObject prefab = Managers.Resource.Instantiate("Character/Player");
        _player = prefab.GetOrAddComponent<PlayerController>();
    }

    public void Over()
    {

    }

    public PlayerController GetPlayer() { return _player; }
}
