using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionNormalScript : MunitionScript
{
    protected override void Effect(PlayerScript player)
    {
        player.HitTaken+=Damage;
        Destroy(gameObject);
    }

    protected override void Effect(ObstDestrScript obstacle)
    {
        obstacle.Pv -= Damage;
        Destroy(gameObject);
    }
}
