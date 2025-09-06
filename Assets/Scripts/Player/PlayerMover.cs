using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private float _groundCheckDistance = 1f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;
    private bool _isMoved = false;

    public bool IsGrounded { get; private set; } = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponentInChildren<Flipper>();
    }

    private void OnEnable()
    {
        _inputReader.Moving += HandleMoveInput;
        _inputReader.JumpPressed += HandleJumpInput;
    }

    private void OnDisable()
    {
        _inputReader.Moving -= HandleMoveInput;
        _inputReader.JumpPressed -= HandleJumpInput;
    }

    private void Update()
    {
        CheckGrounded();
    }

    public void HandleMoveInput(float horizontalInput)
    {
        Move(horizontalInput);
        CheckMovement(horizontalInput);
        _flipper.SetDirection(horizontalInput);
    }

    public void HandleJumpInput()
    {
        if (IsGrounded)
        {
            Jump();
        }
    }

    public void CheckMovement(float speed)
    {
        _isMoved = Mathf.Abs(speed) > 0;
    }

    public bool IsRunning => _isMoved && IsGrounded;

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        IsGrounded = false;
    }

    private void Move(float horizontalInput)
    {
        transform.Translate(new Vector3(horizontalInput * _moveSpeed * Time.deltaTime, 0, 0), Space.World);
    }

    private void CheckGrounded()
    {
        Vector2 rayOrigin = _rigidbody.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, _groundCheckDistance, _groundMask);
        IsGrounded = hit.collider != null;
    }
}