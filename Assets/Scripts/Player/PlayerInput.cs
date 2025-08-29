using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _horizontalInput;
    private bool _jumpPressed;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        HandleInput();
        _player.Move(_horizontalInput);

        if (_jumpPressed )
        {
            _player.Jump();
            _jumpPressed = false;
        }

        _player.CheckMovement(_horizontalInput);
    }

    private void HandleInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _player.IsGrounded)
        {
            _jumpPressed= true;
        }
    }
}
