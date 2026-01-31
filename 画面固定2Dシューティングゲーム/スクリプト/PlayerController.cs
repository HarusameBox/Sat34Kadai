using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _maxPosX;
    [SerializeField] private float _minPosX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("a");
            if (transform.position.x > _minPosX)
            {
                Vector2 pos = transform.position;
                pos.x -= _speed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.x = _minPosX;
                transform.position = pos;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("b");
            if (transform.position.x < _maxPosX)
            {
                Vector2 pos = transform.position;
                pos.x += _speed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                Vector2 pos = transform.position;
                pos.x = _maxPosX;
                transform.position = pos;
            }
        }
    }
}
