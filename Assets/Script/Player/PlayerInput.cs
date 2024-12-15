using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerMain PlayerMain;
    private Vector2 _moveInput;

    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _groundLayer;

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(_groundCheck.position, new Vector2(0, -0.5f), 0, _groundLayer);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        PlayerMain.Movement.SetDirection(_moveInput);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            PlayerMain.Movement.Jump();
        }
    }

    public void OnSpleetScreen(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerMain.SpleetScreen.SpleetScreens();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerMain.Attack.Attack();
        }
    }
}
