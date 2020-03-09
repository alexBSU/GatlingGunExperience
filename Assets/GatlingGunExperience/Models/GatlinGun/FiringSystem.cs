using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSystem : MonoBehaviour
{
    //public AudioSource gunSource;
    public ParticleSystem gunFlash;
    public GameObject spentBullet;
    public AudioSource gunSoundSource;
    public Transform bulletDrop;

    //public float timeToLive = 3f;

    private void OnTriggerEnter(Collider other)
    {
        gunFlash.Play();
        gunSoundSource.PlayOneShot(gunSoundSource.clip);
        Instantiate(spentBullet, bulletDrop);
        //spentBullet.GetComponent<Rigidbody>().velocity = new Vector3(-10, 0, -0);
        
        //Destroy(spentBullet, timeToLive);
    }
}
