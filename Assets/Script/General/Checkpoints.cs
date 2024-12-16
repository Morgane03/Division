using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private Vector2 checkpointPosition;
    public GameObject player;

    private void Start()
    {
        checkpointPosition = transform.position; // Store the checkpoint position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the checkpoint position in the player's script
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.SetCheckpoint(checkpointPosition);
            }
        }
    }
}
