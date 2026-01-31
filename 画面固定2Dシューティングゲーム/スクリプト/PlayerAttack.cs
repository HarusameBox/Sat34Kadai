using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack : MonoBehaviour
{
    private PlayerAttackController _inputs;

    [SerializeField] private GameObject _ammo;

    [SerializeField] private GameObject _fireSpot;

    private void Awake()
    {
        // InputActionAssetのラッパークラスをインスタンス化
        _inputs = new PlayerAttackController();

        // InputActionのコールバックの設定
        // 「Player」はMap名
        // 「Fire」はAction名
        // Map名とAction名は必ずInputActionAssetで設定した名前にする必要がある
        _inputs.PlayerAttack.Attack.performed += OnFire;
    }

    private void OnDestroy()
    {
        // InputActionのコールバックの解除
        _inputs.PlayerAttack.Attack.performed -= OnFire;

        // InputActionAssetのラッパークラスの破棄
        // IDisposableを実装しているので、Disposeする必要がある
        _inputs.Dispose();
    }

    private void OnEnable()
    {
        // 全体のActionを有効化
        _inputs.Enable();
    }

    private void OnDisable()
    {
        // 全体のActionを無効化
        _inputs.Disable();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        print("Fire Actionが呼ばれた！");
        Instantiate(_ammo, _fireSpot.transform.position, Quaternion.identity);
    }
}
