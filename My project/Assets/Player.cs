using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private float _speed = 5f;

    private float _horizontal;
    private float _vertical;

    private Rigidbody2D _rb;
    public int PlayerHealth
    {
        get { return _health; }
        set { _health = value; }
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (_horizontal != 0 && _vertical != 0) 
        {
            _horizontal *= 0.7f;
            _vertical *= 0.7f;
        }
        _rb.velocity = new Vector2(_horizontal * _speed, _vertical * _speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Car")
        {
            _health -= 1;
            if (_health == 0)
            {
                //death
            }
        }
    }
}
