using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionNormalScript : MunitionScript
{
    protected override void Effect(PlayerScript player)
    {
        player.hitTaken+=Damage;
        Destroy(gameObject);
    }
}
