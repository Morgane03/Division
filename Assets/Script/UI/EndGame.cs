using System.Collections;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private ChangeScene _changeScene;

    [SerializeField]
    private int _timeToWait = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(_timeToWait);
        _changeScene.Change();
    }
}
