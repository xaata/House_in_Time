using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float _speed = 2;
    Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (transform.position.y < 0)        
            _renderer.transform.Rotate(180, 0, 0);
    }
    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if (!_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
