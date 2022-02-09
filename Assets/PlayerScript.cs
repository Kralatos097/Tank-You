using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    [Header("Values")]
    public int MoveSpeed;
    public int RotateSpeed;
    
    //Private
    private float _moveDir = 0;
    private float _rotateDir = 0;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.forward * _moveDir * MoveSpeed * Time.deltaTime;
        Vector3 rotate = Vector3.up * _rotateDir * RotateSpeed*10 * Time.deltaTime;
        
        /*transform.Translate(move);
        //_rb.MovePosition(transform.position + move);
        
        transform.Rotate(rotate);*/
    }

    public void OnNormalFire()
    {
        Debug.Log("Fire!");
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
