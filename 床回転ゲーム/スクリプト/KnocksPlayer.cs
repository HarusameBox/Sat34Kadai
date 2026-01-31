using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnocksPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private float _knockbackForce = 10f;

    [SerializeField] private Vector3 _knockbackDirection;

    public void FlyAway()
    {
        _rigidBody.AddForce(_knockbackDirection.normalized * _knockbackForce, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }
}
