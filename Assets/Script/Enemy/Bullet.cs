using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Vitesse du projectile
    [SerializeField] private float lifetime = 3f; // Durée de vie du projectile avant de disparaître

    private Vector2 direction; // Direction dans laquelle le projectile est tiré

    private void OnEnable()
    {
        // Réinitialiser la durée de vie du projectile
        Invoke("Deactivate", lifetime);
    }

    private void OnDisable()
    {
        // Annuler l'invocation lorsque le projectile est désactivé
        CancelInvoke();
    }

    private void Update()
    {
        // Déplacer le projectile dans la direction donnée
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // Normaliser la direction pour assurer une vitesse constante
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); // Désactiver le projectile après la durée de vie
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Exemple de détection de collision avec un joueur
        {
            Deactivate(); // Désactiver le projectile après avoir touché un ennemi
        }
    }
}
