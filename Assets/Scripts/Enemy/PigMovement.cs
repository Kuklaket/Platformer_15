using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class PigMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _currentWaypoint = 0;
    private float _distanceToWaypointThreshold = 0.1f;
    private int _waypointStep = 1;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) < _distanceToWaypointThreshold)
            _currentWaypoint = (_currentWaypoint + _waypointStep) % _waypoints.Length;

        transform.position = Vector3.MoveTowards( transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x < _waypoints[_currentWaypoint].position.x)
            _spriteRenderer.flipX = false; 
        else if (transform.position.x > _waypoints[_currentWaypoint].position.x)
            _spriteRenderer.flipX = true;
    }
}

