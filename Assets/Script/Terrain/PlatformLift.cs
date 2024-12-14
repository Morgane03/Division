using System.Collections;
using UnityEngine;

public class PlatformLift : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _height;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovePlatform(new Vector2(transform.position.x, transform.position.y + _height), _duration));
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

        //StartCoroutine(MovePlatform(new Vector2(transform.position.x, transform.position.y - _height), _duration));
    }
}
