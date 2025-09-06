using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private PlayerMover _playerMover;
    private Animator _animator;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, _playerMover.IsRunning);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, !_playerMover.IsGrounded);
    }
}