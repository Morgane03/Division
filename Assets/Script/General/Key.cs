using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isCollected = false; // Indique si la cl� a �t� collect�e

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifiez si le collider qui touche la cl� a un certain tag, par exemple "Player"
        if (collision.CompareTag("Player"))
        {
            // D�finir la cl� comme collect�e
            isCollected = true;

            // D�sactiver l'objet de la cl�
            gameObject.SetActive(false);

            // Optionnel : Vous pouvez jouer un son ou une animation ici
        }
    }
}
