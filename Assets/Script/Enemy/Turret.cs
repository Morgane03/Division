using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform _target; // La cible que la tourelle va suivre

    [SerializeField] private float _range = 5f; // La port�e de tir
    [SerializeField] private float _fireRate = 1f; // Taux de tir (tirs par seconde)
    [SerializeField] private float _rotationSpeed = 2f; // Vitesse de rotation de la tourelle

    public Transform firePoint; // Le point d'o� le projectile sera tir�

    public CircleCollider2D rangeCollider; // Le collider de port�e de la tourelle

    private float _fireCooldown = 0f; // Compte � rebours pour le tir

    private void Update()
    {
        if (_target != null)
        {
            // Regarder la cible
            Vector2 direction = (_target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            // G�rer le tir
            _fireCooldown -= Time.deltaTime;
            if (_fireCooldown <= 0f)
            {
                Fire();
                _fireCooldown = 1f / _fireRate; // R�initialiser le compte � rebours
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
            _target = null; // Arr�ter de suivre si le joueur sort de la port�e
        }
    }

    void Fire()
    {
        // Cr�er un projectile
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
                bulletScript.SetDirection(direction); // Passer la direction calcul�e au projectile
            }
        }
    }
}
