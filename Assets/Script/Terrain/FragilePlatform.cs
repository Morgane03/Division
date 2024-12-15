 using UnityEngine;
using System.Collections;

public class FragilePlatform : MonoBehaviour
{
    public float breakDelay = 0.5f; // Délai avant que la plateforme se casse
    [SerializeField] private GameObject _playerRobot;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifiez si le collider qui touche la plateforme a un certain tag, par exemple "Player"
        if (collision.gameObject.CompareTag("Player") && collision.gameObject == _playerRobot)
        {
            // Commencez la coroutine pour casser la plateforme après un délai
            StartCoroutine(BreakPlatform());
        }
    }

    private IEnumerator BreakPlatform()
    {
        // Attendre le délai défini
        yield return new WaitForSeconds(breakDelay);

        // Désactiver la plateforme ou jouer une animation de casse
        gameObject.SetActive(false);

        // Optionnel : Vous pouvez jouer un son ou une animation ici
    }
}
