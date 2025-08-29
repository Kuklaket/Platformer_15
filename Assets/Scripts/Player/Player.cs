using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private float _groundCheckDistance = 1f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private CoinsCounter _coinsCounterPrefab;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private CoinsCounter _coinsCounter;
    private bool _isFacingRight = true;
    private bool _isMoved = false;
    private float _flipScale = -1f;

    public bool IsGrounded { get ; private set ; } = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _coinsCounter = Instantiate(_coinsCounterPrefab, new Vector2(-11, 3), Quaternion.identity);
    }

    private void Update()
    {
        UpdateAnimations();
        CheckGrounded();
    }

    public CoinsCounter GetCoinsCounter() => _coinsCounter;

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        IsGrounded = false;
        _animator.SetBool(HashForTags.Jump,true);
    }

    public void CheckMovement(float speed)
    {
        _isMoved = Mathf.Abs(speed) > 0;
    }

    public void Move(float horizontalInput)
    {
        transform.Translate(new Vector3(horizontalInput * _moveSpeed * Time.deltaTime, 0, 0));

        if (horizontalInput > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void CheckGrounded()
    {
        Vector2 rayOrigin = _rigidbody.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, _groundCheckDistance, _groundMask);
        IsGrounded = hit.collider != null;
    }

    private void UpdateAnimations()
    {
        bool isRunning = _isMoved && IsGrounded;

        _animator.SetBool(HashForTags.Run, isRunning);
        _animator.SetBool(HashForTags.Jump, !IsGrounded);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= _flipScale;
        transform.localScale = scale;
    }
}
