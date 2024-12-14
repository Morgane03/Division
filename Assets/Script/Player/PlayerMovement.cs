using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Events
    //public event Action StartedMoving;
    //public event Action StoppedMoving;

    private Vector2 _moveInput;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }



    public void SetDirection(Vector2 direction)
    {
        _moveInput = direction;
    }

    private void FixedUpdate()
    {
        Vector2 movement = _moveInput * moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    public void Jump()
    {
        //_rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }
}
