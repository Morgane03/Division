using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform _target; // La cible que la tourelle va suivre

    [SerializeField] private float _range = 5f; // La portée de tir
    [SerializeField] private float _fireRate = 1f; // Taux de tir (tirs par seconde)
    [SerializeField] private float _rotationSpeed = 2f; // Vitesse de rotation de la tourelle

    public Transform firePoint; // Le point d'où le projectile sera tiré

    public CircleCollider2D rangeCollider; // Le collider de portée de la tourelle

    private float _fireCooldown = 0f; // Compte à rebours pour le tir

    private void Update()
    {
        if (_target != null)
        {
            // Regarder la cible
            Vector2 direction = (_target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            // Gérer le tir
            _fireCooldown -= Time.deltaTime;
            if (_fireCooldown <= 0f)
            {
                Fire();
                _fireCooldown = 1f / _fireRate; // Réinitialiser le compte à rebours
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _target = null; // Arrêter de suivre si le joueur sort de la portée
        }
    }

    void Fire()
    {
        // Créer un projectile
        GameObject bullet = ObjectPool.Instance.RequestObject(0);
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.SetActive(true); // Activer le projectile

            // Donne une direction et une vitesse au projectile
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                // Calculer la direction vers la cible
                Vector2 direction = (_target.position - firePoint.position).normalized;
                bulletScript.SetDirection(direction); // Passer la direction calculée au projectile
            }
        }
    }
}
