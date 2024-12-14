using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isCollected = false; // Indique si la clé a été collectée

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifiez si le collider qui touche la clé a un certain tag, par exemple "Player"
        if (collision.CompareTag("Player"))
        {
            // Définir la clé comme collectée
            isCollected = true;

            // Désactiver l'objet de la clé
            gameObject.SetActive(false);

            // Optionnel : Vous pouvez jouer un son ou une animation ici
        }
    }
}
