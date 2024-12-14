using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMain playerMain;
    private Vector2 currentCheckpoint;

    private void Start()
    {
        FindObjectOfType<Bullet>().OnHit += Respawn; // Subscribe to the OnHit event)
        currentCheckpoint = transform.position; // Set the initial spawn position as the checkpoint
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        currentCheckpoint = checkpointPosition; // Update the checkpoint position
    }

    public void Respawn()
    {
        playerMain.SpleetScreen.SpleetScreenOff(); // Disable the split screen (if it's enabled 
        transform.position = currentCheckpoint; // Respawn the player at the checkpoint
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Respawn();
        }
    }
}
