 using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject _bigPlayer;

    // V1 en attendant effet de destruction
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _bigPlayer)
        {
            Destroy(this.gameObject);
        }
    }
}
