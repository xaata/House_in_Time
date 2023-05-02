using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int _health;
    private float _speed = 1.8f;

    private float _horizontal;
    private float _vertical;

    [SerializeField]
    private Sprite _openedDoorSprite;
    
    

    private Rigidbody2D _rb;
    [SerializeField]
    private GameObject _pickedTV;

    private bool _keyPickedUp = false;
    private bool _tvPickedUp = false;

    private bool _onPlace = false;
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

        if (Input.GetKeyDown(KeyCode.Space) && _onPlace == true)
        {
            Instantiate(_pickedTV, transform.position,Quaternion.identity);
            
            var timer = Time.deltaTime;
            Invoke("End", 2);
            
        }
        
    }
    private void End()
    {
        SceneManager.LoadScene("End");
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
            SceneManager.LoadScene("Death");
            UnityEngine.Debug.Log("Death");
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key")
        {
            _keyPickedUp = true;
            collision.gameObject.SetActive(false);
            _tvPickedUp = true;
            UnityEngine.Debug.Log("Key");
        }
        if (collision.tag == "RedDoor" && _keyPickedUp)
        {
            collision.gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.transform.parent.GetComponent<SpriteRenderer>().sprite = _openedDoorSprite;
            collision.gameObject.transform.parent.position += new Vector3(0f, 1.2f , 0);
            UnityEngine.Debug.Log("RedDoor");
        }
        
        if (collision.tag == "Door")
        {
            SceneManager.LoadScene("Scene2");
            UnityEngine.Debug.Log("Door");
        }
        if(collision.tag == "TV")
        {
            _tvPickedUp = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "UpStairs")
        {
            if (_tvPickedUp)
            {
                _onPlace = true;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "UpStairs")
        {
            if (_tvPickedUp)
            {
                _onPlace = true;
            }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "PutPlace")
    //    {
    //        if (_tvPickedUp)
    //        {
    //            _onPlace = false;
    //        }
    //    }
    //}
}
