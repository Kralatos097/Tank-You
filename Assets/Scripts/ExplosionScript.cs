using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public int Damage = 3;
    public float Duration = 1f;

    private void Start()
    {
        Invoke("DestroyThis", Duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().HitTaken += Damage;
        }
        if (other.GetComponent<ObstDestrScript>())
        {
            other.GetComponent<ObstDestrScript>().Pv -= Damage;
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
