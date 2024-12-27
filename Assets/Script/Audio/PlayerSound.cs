using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _footstepClips;

    public void PlayFootstepSound()
    {
        _audioSource.PlayOneShot(_footstepClips[Random.Range(0, _footstepClips.Count)]);
    }
}
