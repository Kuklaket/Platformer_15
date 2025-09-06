using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private Transform _visualTransform;

    private bool _isFacingRight = true;
    private float _rightRotation = 0f;
    private float _leftRotation = 180f;

    private void Awake()
    {
        _visualTransform = transform;
    }

    public void SetDirection(float xDirection)
    {
        bool shouldFaceRight = xDirection > 0;

        if (Mathf.Abs(xDirection) < 0.1f) return;

        if (shouldFaceRight != _isFacingRight)
        {
            Flip(shouldFaceRight);
        }
    }

    public void Flip(bool faceRight)
    {
        if (_isFacingRight == faceRight) return;

        _isFacingRight = faceRight;
        float targetRotation = faceRight ? _rightRotation : _leftRotation;
        _visualTransform.localRotation = Quaternion.Euler(0f, targetRotation, 0f);
    }
}
