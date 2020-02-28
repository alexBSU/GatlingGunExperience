using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSystem : MonoBehaviour
{
    //public AudioSource gunSource;
    public ParticleSystem gunFlash;

    public AudioSource gunSoundSource;

    private void OnTriggerEnter(Collider other)
    {
        gunFlash.Play();
        gunSoundSource.PlayOneShot(gunSoundSource.clip);
    }
}
