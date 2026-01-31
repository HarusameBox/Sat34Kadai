using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomerang : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _boomerangPrefab;
    [SerializeField] private Vector3 _spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Throw");
        }
    }

    //  ブーメランの生成等を行う
    public void Throw()
    {
        Transform playerTransform = gameObject.GetComponent<Transform>();
        Vector3 boomerangPlace = new Vector3(playerTransform.position.x, playerTransform.position.y + _spawnPoint.y , playerTransform.position.z + _spawnPoint.z);
        GameObject boomerang = Instantiate(_boomerangPrefab, boomerangPlace, _boomerangPrefab.transform.rotation);
        Boomerang boomerangScript = boomerang.GetComponent<Boomerang>();
        boomerangScript._player = this.gameObject;
    }
}
