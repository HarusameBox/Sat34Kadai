using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider _collider;
    
    //  ブーメランを当てられたら再起不能
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boomerang"))
        {
            _animator.SetTrigger("Defeated");
            _collider.enabled = false;
        }
    }
}
