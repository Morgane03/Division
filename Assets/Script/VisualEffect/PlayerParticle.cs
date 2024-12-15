using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    [SerializeField]
    private GameObject _particle;

    public void PlayParticle()
    {
        _particle.SetActive(true);
    }

    public void StopParticle()
    {
        _particle.SetActive(false);
    }
}
