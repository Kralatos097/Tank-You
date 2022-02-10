using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [Header("Playe 1 UI")]
    public TextMeshProUGUI PointCountP1;
    
    [Header("Playe 2 UI")]
    public TextMeshProUGUI PointCountP2;
    
    private void Start()
    {
        PlayerScript.OnHitTaken += delegate(int i, bool b)
        {
            if(b)
            {
                PointCountP1.text = i.ToString();
            }
            else
            {
                PointCountP2.text = i.ToString();
            }
        };
    }
}
