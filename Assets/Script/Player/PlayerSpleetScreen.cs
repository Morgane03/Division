using UnityEngine;

public class PlayerSpleetScreen : MonoBehaviour
{
    //Camera
    [SerializeField]
    private Camera _cameraSplit;
    [SerializeField]
    private Camera _cameraMain;

    [SerializeField] private Sprite _spriteRobot;
    [SerializeField] private Sprite _spriteJoueur1;

    [SerializeField] private RuntimeAnimatorController _animPlayer1;
    [SerializeField] private RuntimeAnimatorController _animRobotSolo;

    //Player
    [SerializeField]
    private GameObject _player2;
    [SerializeField]
    private GameObject _player1;

    private bool _isSpleetScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        _cameraSplit.gameObject.SetActive(false);
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
        _cameraMain.rect = new Rect(0f, 0, 0.5f, 1);
        _cameraSplit.gameObject.SetActive(true);
        _player1.transform.position = _player2.transform.position + new Vector3(2.5f, 0, 0);
        _player1.SetActive(true);
        _player2.GetComponent<SpriteRenderer>().sprite = _spriteJoueur1;
        _player2.GetComponent<Animator>().runtimeAnimatorController = _animRobotSolo;
    }

    public void SpleetScreenOff()
    {
        _player2.GetComponent<SpriteRenderer>().sprite = _spriteRobot;
        _player2.GetComponent<Animator>().runtimeAnimatorController = _animPlayer1;
        _cameraMain.rect = new Rect(0, 0, 1, 1);
        _cameraSplit.gameObject.SetActive(false);
        _player1.SetActive(false);
        //_player1.transform.position = _player2.transform.position + new Vector3(0.5f, 0, 0);
        _isSpleetScreen = false;
    }
}
