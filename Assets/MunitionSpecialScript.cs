using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionSpecialScript : MunitionScript
{
    protected override void Effect(PlayerScript player)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
