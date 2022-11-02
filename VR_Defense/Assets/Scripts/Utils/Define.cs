using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{ 
    public enum Scene
    {
        Title,
        Game
    }

    public enum UIEvent
    {
        Click
    }

    public enum SFX
    {

    }

    public enum BGM
    {
        
    }

    public enum State
    {
        Move,
        Attack,
        Hit,
        Die
    }

    public enum AudioSources
    {
        Unknown,
        BGM,
        SFX
    }

    public enum Creature
    {
        Player,
        Mob
    }

    public enum MobType
    {
        Wolf,
        InfernoDragon,
        Crab
    }
}
