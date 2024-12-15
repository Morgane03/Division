using System.Collections;
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

    private bool _camJump = true;

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        PlayerMain.Movement.SetDirection(_moveInput);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ground"))
    //    {
    //        Debug.Log(collision.gameObject.tag);
    //        Debug.Log("Ground");
    //        _camJump = true;
    //        Debug.Log(_camJump);
    //    }
    //}

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(1f);
        _camJump = true;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _camJump)
        {
            PlayerMain.Movement.Jump();
            _camJump = false;
            StartCoroutine(Jump());
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
