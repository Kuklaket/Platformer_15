using UnityEngine;

public class PigMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Flipper _flipper;

    private int _currentWaypoint = 0;
    private float _distanceToWaypointThreshold = 0.1f;
    private int _waypointStep = 1;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        Move();
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        float direction = _waypoints[_currentWaypoint].position.x - transform.position.x;
        _flipper.SetDirection(direction);
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) < _distanceToWaypointThreshold)
            _currentWaypoint = (_currentWaypoint + _waypointStep) % _waypoints.Length;

        transform.position = Vector3.MoveTowards( transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}

