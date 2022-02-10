using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Values")]
    public int MoveSpeed;
    public int RotateSpeed;
    public bool IsPlayerOne;
    
    public static Action<int, bool> OnHitTaken;
    private int _hitTakken;
    public int hitTaken
    {
        get => _hitTakken;

        set
        {
            _hitTakken = value;
            Debug.Log(_hitTakken);
            OnHitTaken.Invoke(_hitTakken, IsPlayerOne);
        }
    }

    [Header("Drag'n Drop")]
    public GameObject ObusNPrefab;
    public GameObject ObusSPrefab;
    
    //Private
    private float _moveDir = 0;
    private float _rotateDir = 0;
    private CharacterController _cc;
    
    // Start is called before the first frame update
    void Start()
    {
        _cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.TransformDirection(Vector3.forward * _moveDir * MoveSpeed * Time.deltaTime);
        Vector3 rotate = Vector3.up * _rotateDir * RotateSpeed*10 * Time.deltaTime;
        
        _cc.Move(move);
        transform.Rotate(rotate);
    }

    public void OnNormalFire()
    {
        Instantiate(ObusNPrefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }
    
    public void OnSpecialFire()
    {
        Debug.Log("Booom!");
    }

    public void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        _moveDir = value.Get<Vector2>().y;
    }
    
    public void OnRotate(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        _rotateDir = value.Get<Vector2>().x;
    }
}
