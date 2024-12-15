using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

    [Header("Animator")]
    [SerializeField]
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _playerMain.Movement.StartedMoving += OnStartedMoving;
        _playerMain.Movement.StoppedMoving += OnStoppedMoving;

        _playerMain.Movement.Jumped += OnJump;
        _playerMain.Attack.Attacked += OnAttack;
        _playerMain.Movement.Landed += OnFalling;
    }

    void OnStartedMoving()
    {
        _anim.SetBool("IsMoving", true);
    }

    void OnStoppedMoving()
    {
        _anim.SetBool("IsMoving", false);
    }

    void OnJump()
    {
        _anim.SetTrigger("IsJumping");
    }

    void OnFalling()
    {
        _anim.SetTrigger("IsFalling");
    }

    void OnAttack()
    {
        _anim.SetTrigger("IsAttacking");
    }
}
