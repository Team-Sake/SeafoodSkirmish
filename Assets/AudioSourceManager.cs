using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSourceManager : MonoBehaviour
{
    public AudioSource audioSourceManager;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip damaged;

    public void PlayHit()
    {
        audioSourceManager.PlayOneShot(hit);
    }

    public void PlayDamaged()
    {
        audioSourceManager.PlayOneShot(damaged);
    }
}
