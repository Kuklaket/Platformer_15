using UnityEngine;

public class PlayerComposer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        ComposePlayer();
    }

    private void ComposePlayer()
    {
        _playerMover.Initialize(_inputReader);
        _jumper.Initialize(_inputReader);
    }
}