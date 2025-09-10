using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    public event UnityAction<float> Moving;
    public event UnityAction JumpPressed;

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis(Horizontal);
        Moving?.Invoke(horizontalInput);
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown(Jump))
            JumpPressed?.Invoke();
    }
}