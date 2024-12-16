using UnityEngine;

public class Key : MonoBehaviour
{
    [HideInInspector]
    public bool isCollected = false; // Indique si la clé a été collectée

    [SerializeField] private GameObject _door; // Référence à l'objet de la porte
    [SerializeField] private Sprite _doorOpen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifiez si le collider qui touche la clé a un certain tag, par exemple "Player"
        if (collision.CompareTag("Player"))
        {
            // Définir la clé comme collectée
            isCollected = true;

            // Désactiver l'objet de la clé
            gameObject.SetActive(false);
            _door.GetComponent<SpriteRenderer>().sprite = _doorOpen;

            // Optionnel : Vous pouvez jouer un son ou une animation ici
        }
    }
}
