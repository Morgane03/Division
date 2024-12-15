using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public event Action Attacked;

    public void Attack()
    {
        Debug.Log("Attack");
        // lance animation attack si touche ennemi alors tue ennemi
        Attacked?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
