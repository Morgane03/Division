using UnityEngine;

public class PlayerSpleetScreen : MonoBehaviour
{
    //Camera
    [SerializeField]
    private Camera _cameraPlayer1;
    [SerializeField]
    private GameObject _cameraPlayer2;

    //Player
    [SerializeField]
    private GameObject _player2;
    [SerializeField]
    private GameObject _player1;

    private bool _isSpleetScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        _cameraPlayer2.GetComponent<Camera>();
    }

    public void SpleetScreens()
    {
        if(_isSpleetScreen)
        {
            _isSpleetScreen = false;
            SpleetScreenOff();
        }
        else
        {
            _isSpleetScreen = true;
            SpleetScreenOn();
        }
        
    }

    private void SpleetScreenOn()
    {
        _cameraPlayer1.rect = new Rect(-0.5f, 0, 1, 1);
        _cameraPlayer2.SetActive(true);
        _player2.SetActive(true);
        _cameraPlayer2.GetComponent<Camera>().rect = new Rect(0.5f, 0, 1, 1);
    }

    public void SpleetScreenOff()
    {
        _cameraPlayer1.rect = new Rect(0, 0, 1, 1);
        _cameraPlayer2.SetActive(false);
        _player2.SetActive(false);
        _player2.transform.position = _player1.transform.position + new Vector3(-0.5f, 0, 0);
        _isSpleetScreen = false;
    }
}
