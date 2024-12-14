using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMain playerMain;
    private Vector2 currentCheckpoint;

    private void Start()
    {
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
}
