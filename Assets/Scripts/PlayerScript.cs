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
    public float NormalCD;
    public float SpecialCD;
    public bool IsPlayerOne;
    
    public static Action<int, bool> OnHitTaken;
    private int _hitTakken;
    public int HitTaken
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
    private float _currNormalCD;
    private float _currSpecialCD;
    private CharacterController _cc;
    
    // Start is called before the first frame update
    void Start()
    {
        _cc = gameObject.GetComponent<CharacterController>();

        _currNormalCD = NormalCD;
        _currSpecialCD = SpecialCD;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouvement Player
        Vector3 move = transform.TransformDirection(Vector3.forward * _moveDir * MoveSpeed * Time.deltaTime);
        Vector3 rotate = Vector3.up * _rotateDir * RotateSpeed*10 * Time.deltaTime;
        
        _cc.Move(move);
        transform.Rotate(rotate);
        
        //Fire CoolDown
        if(_currNormalCD >= 0)
        {
            _currNormalCD -= Time.deltaTime;
        }
        if(_currSpecialCD >= 0)
        {
            _currSpecialCD -= Time.deltaTime;
        }
    }

    public void OnNormalFire()
    {
        if (_currNormalCD <= 0)
        {
            Instantiate(ObusNPrefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
            _currNormalCD = NormalCD;
        }
    }
    
    public void OnSpecialFire()
    {
        if (_currSpecialCD <= 0)
        {
            Instantiate(ObusSPrefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
            _currSpecialCD = SpecialCD;
        }   
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
