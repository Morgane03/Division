using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private GameObject _transitionScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                _transitionScreen.SetActive(true);
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                //playerController.Respawn();
            }
        }
    }
}
