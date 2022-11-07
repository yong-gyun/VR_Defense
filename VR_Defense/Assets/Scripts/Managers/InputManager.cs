using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public LaserPointer LaserPointer
    {
        get
        {
            if(_laserPointer == null)
            {
                GameObject go = GameObject.Find("LaserPointer");
                _laserPointer = go.GetComponent<LaserPointer>();
            }

            return _laserPointer;
        }
    }

    private LaserPointer _laserPointer;
    
}
