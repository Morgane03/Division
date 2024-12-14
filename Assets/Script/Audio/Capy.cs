using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capy : MonoBehaviour
{
    [SerializeField] private AudioClip _capy;
    [SerializeField] private AudioSource _capySource;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _capySource.PlayOneShot(_capy);
        }
    }
}
