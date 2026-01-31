using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateSpeed;
    [SerializeField] private float _firstPower;
    [SerializeField] private float _returnPower;
    [SerializeField] private ParticleSystem _particleSystem;

    public GameObject _player;

    private Rigidbody _rigidBody;



    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _rigidBody.AddForce(transform.forward * _firstPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = this.transform;

        transform.Rotate(_rotateSpeed.x * Time.deltaTime, _rotateSpeed.y * Time.deltaTime, _rotateSpeed.z * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized;
        if (_player != null)
        {
            _rigidBody.AddForce(directionToPlayer * _returnPower);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            _particleSystem.Play();
        }
    }
}
