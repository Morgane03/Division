using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Key key; // R�f�rence � l'objet de la cl�
    [SerializeField] private int level = 1;

    [SerializeField] private List<GameObject> levels;
    [SerializeField] private List<GameObject> _keysPosition;
    [SerializeField] private List<GameObject> _doorsPosition;

    [SerializeField] private TextMeshProUGUI _infoText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifiez si le collider qui touche la porte a un certain tag, par exemple "Player"
        if(collision.gameObject.CompareTag("Player"))
        {
            // V�rifiez si la cl� a �t� collect�e
            if (key.isCollected)
            {
                switch (level)
                {
                    case 1:
                        // Charger le niveau 1
                        collision.gameObject.transform.position = levels[0].transform.position;
                        key.transform.position = _keysPosition[0].transform.position;
                        _infoText.gameObject.transform.position = _doorsPosition[0].transform.position;
                        Next();
                        break;
                    case 2:
                        collision.gameObject.transform.position = levels[1].transform.position;
                        key.transform.position = _keysPosition[1].transform.position;
                        _infoText.gameObject.transform.position = _doorsPosition[1].transform.position;
                        Next();
                        break;
                    case 3:
                        collision.gameObject.transform.position = levels[2].transform.position;
                        key.transform.position = _keysPosition[2].transform.position;
                        _infoText.gameObject.transform.position = _doorsPosition[2].transform.position;
                        break;
                    default:
                        Debug.Log("Niveau non d�fini !");
                        break;
                }
            }
            else
            {
                _infoText.text = "Vous devez collecter la cl� pour ouvrir la porte !";
            }
        }
    }

    void Next()
    {
        level++;
        key.isCollected = false;
    }
}
