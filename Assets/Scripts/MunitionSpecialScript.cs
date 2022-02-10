using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionSpecialScript : MunitionScript
{
    public GameObject ExplosionPrefab;
    
    protected override void Effect(PlayerScript player)
    {
        Destroy(gameObject);
    }

    protected override void Effect(ObstDestrScript obstacle)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }
}
