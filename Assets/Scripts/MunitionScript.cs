using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MunitionScript : MonoBehaviour
{
    public int Speed;
    public int Damage;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        Vector3 moveForce = transform.TransformDirection(Vector3.forward * Speed);
        _rb.AddForce(moveForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerScript>())
        {
            Effect(other.GetComponent<PlayerScript>());
        }
        else if(other.GetComponent<ObstDestrScript>())
        {
            Effect(other.GetComponent<ObstDestrScript>());
        }
        else if(other.CompareTag("Explosion")) {return;}
        else
        {
            Destroy(gameObject);
        }
    }

    protected abstract void Effect(PlayerScript player);
    
    protected abstract void Effect(ObstDestrScript obstacle);
}
