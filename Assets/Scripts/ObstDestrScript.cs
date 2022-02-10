using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstDestrScript : MonoBehaviour
{
    public int PvMax = 3;
    private int _currPv;
    public int Pv
    {
        get => _currPv;

        set
        {
            _currPv = value;
            if (_currPv <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        _currPv = PvMax;
    }
}
