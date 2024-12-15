using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    // Events
    public event Action StartedMoving;
    public event Action StoppedMoving;

    public event Action Jumped;
    public event Action Landed;

    [SerializeField]
    private PlayerMain _playerMain;

    private Vector2 _moveInput;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;
    private float _gravity = -9.8f;

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }



    public void SetDirection(Vector2 direction)
    {
        _moveInput = direction;

        if (_moveInput != Vector2.zero)
        {
            if(_moveInput.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(_moveInput.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            StartedMoving?.Invoke();
        }
        else
        {
            StoppedMoving?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVelocity = new Vector2(_moveInput.x * moveSpeed, _rb.velocity.y);
        _rb.velocity = moveVelocity;

        if(_moveInput.y < 0)
        {
            Landed?.Invoke();
        }
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Jumped?.Invoke();
    }
}
