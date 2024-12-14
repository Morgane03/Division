using System.Collections;
using UnityEngine;

public class PlatformLift : MonoBehaviour
{
    [SerializeField] private float _timeToClimb;
    [SerializeField] private float _height;
    [SerializeField] private float _durationWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlatformLoop());
    }

    private IEnumerator MovePlatformLoop()
    {
        while (true) // Boucle infinie
        {
            yield return StartCoroutine(MovePlatform(new Vector2(transform.position.x, transform.position.y + _height), _timeToClimb));
            yield return StartCoroutine(MovePlatform(new Vector2(transform.position.x, transform.position.y - _height), _timeToClimb)); // Retour à la position de départ
        }
    }

    private IEnumerator MovePlatform(Vector2 targetPos, float duration)
    {
        float time = 0;
        Vector2 startPos = transform.position;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        yield return new WaitForSeconds(_durationWait);
    }
}
