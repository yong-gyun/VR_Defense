using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float damage;
    private Gun _gun = null;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RHand))
        {
            _gun.OnShooting();
        }

        //ARAVRInput.DrawCrosshair();
    }
    
    public void Init()
    {
        _gun = Util.GetOrAddComponent<Gun>(gameObject);
    }
}