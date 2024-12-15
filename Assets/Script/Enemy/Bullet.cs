using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Vitesse du projectile
    [SerializeField] private float lifetime = 3f; // Dur�e de vie du projectile avant de dispara�tre

    private Vector2 direction; // Direction dans laquelle le projectile est tir�

    private void OnEnable()
    {
        // R�initialiser la dur�e de vie du projectile
        Invoke("Deactivate", lifetime);
    }

    private void OnDisable()
    {
        // Annuler l'invocation lorsque le projectile est d�sactiv�
        CancelInvoke();
    }

    private void Update()
    {
        // D�placer le projectile dans la direction donn�e
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // Normaliser la direction pour assurer une vitesse constante
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); // D�sactiver le projectile apr�s la dur�e de vie
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Exemple de d�tection de collision avec un joueur
        {
            Deactivate(); // D�sactiver le projectile apr�s avoir touch� un ennemi
        }
    }
}
