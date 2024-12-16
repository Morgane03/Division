using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Key key; // Référence à l'objet de la clé
    [SerializeField] private int level = 1;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _playerRobot;

    [SerializeField] private List<GameObject> levels;
    [SerializeField] private List<GameObject> _keysPosition;
    [SerializeField] private List<GameObject> _doorsPosition;

    [SerializeField] private TextMeshProUGUI _infoText;

    [SerializeField] private string _sceneName;

    [SerializeField] private PlayerSpleetScreen _playerScreen;

    [SerializeField] private Sprite _doorClose;
    [SerializeField] private Sprite _doorOpen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifiez si le collider qui touche la porte a un certain tag, par exemple "Player"
        if(collision.gameObject.CompareTag("Player"))
        {
            // Vérifiez si la clé a été collectée
            if (key.isCollected)
            {
                _door.GetComponent<SpriteRenderer>().sprite = _doorOpen;

                switch (level)
                {
                    case 1:
                        // Charger le niveau 1
                        _playerRobot.transform.position = levels[0].transform.position;
                        key.transform.position = _keysPosition[0].transform.position;
                        _door.transform.position = _doorsPosition[0].transform.position;
                        Next();
                        break;
                    case 2:
                        _playerRobot.transform.position = levels[1].transform.position;
                        _door.GetComponent<SpriteRenderer>().flipX = true;
                        key.transform.position = _keysPosition[1].transform.position;
                        _door.transform.position = _doorsPosition[1].transform.position;
                        Next();
                        break;
                    case 3:
                        _playerRobot.transform.position = levels[2].transform.position;
                        _door.GetComponent<SpriteRenderer>().flipX = true;
                        key.transform.position = _keysPosition[2].transform.position;
                        _door.transform.position = _doorsPosition[2].transform.position;
                        break;
                    case 4:
                        _playerRobot.transform.position = levels[3].transform.position;
                        _door.GetComponent<SpriteRenderer>().flipX = true;
                        key.transform.position = _keysPosition[3].transform.position;
                        _door.transform.position = _doorsPosition[3].transform.position;
                        break;
                    case 5:
                        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
                        break;
                    default:
                        Debug.Log("Niveau non défini !");
                        break;
                }
            }
            else
            {
                _infoText.gameObject.SetActive(true);
                _infoText.text = "Vous devez collecter la clé pour ouvrir la porte !";
                StartCoroutine(DisableText());
            }
        }
    }

    void Next()
    {
        level++;
        key.isCollected = false;
        _door.GetComponent<SpriteRenderer>().flipX = false;
        _door.GetComponent<SpriteRenderer>().sprite = _doorClose;
        _playerScreen.SpleetScreenOff();
        key.gameObject.SetActive(true);
    }

    private IEnumerator DisableText()
    {
        yield return new WaitForSeconds(2f);
        _infoText.gameObject.SetActive(false);
    }
}
