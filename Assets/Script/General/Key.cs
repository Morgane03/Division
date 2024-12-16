using UnityEngine;

public class Key : MonoBehaviour
{
    [HideInInspector]
    public bool isCollected = false; // Indique si la cl� a �t� collect�e

    [SerializeField] private GameObject _door; // R�f�rence � l'objet de la porte
    [SerializeField] private Sprite _doorOpen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifiez si le collider qui touche la cl� a un certain tag, par exemple "Player"
        if (collision.CompareTag("Player"))
        {
            // D�finir la cl� comme collect�e
            isCollected = true;

            // D�sactiver l'objet de la cl�
            gameObject.SetActive(false);
            _door.GetComponent<SpriteRenderer>().sprite = _doorOpen;

            // Optionnel : Vous pouvez jouer un son ou une animation ici
        }
    }
}
