using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Actionをインスペクターから編集できるようにする
    private PlayerController _input;

    private bool _isInputRegistrationed = false;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private float _jumpForce;

    private bool _isJumping = false;

    public bool _isFailed = false;

    private void Awake()
    {
        _input = new PlayerController();
    }

    private void OnEnable()
    {
        if (!_isInputRegistrationed)
        {
            // Actionのコールバックを登録
            _input.PlayerMove.PlayerJump.performed += OnPerformed;
        }
        
        // InputActionを有効化
        _input.PlayerMove.Enable();
    }

    private void OnDisable()
    {
        // 自身が無効化されるタイミングなどで
        // Actionを無効化する必要がある
        _input.PlayerMove.Disable();

        if (!_isInputRegistrationed)
        {
            // Actionのコールバックを解除
            _input.PlayerMove.PlayerJump.performed -= OnPerformed;
            _isInputRegistrationed = false;
        }
    }

    private void OnDestroy()
    {
        // 最終的な片付け
        if (_input != null)
        {
            _input.PlayerMove.Disable();
            _input.Dispose();
            _input = null;
        }
    }

    // コールバックを受け取ったときの処理
    private void OnPerformed(InputAction.CallbackContext context)
    {
        if (!_isJumping && !_isFailed)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        if(_rigidBody.velocity != Vector3.zero)
        {
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
    }
}
