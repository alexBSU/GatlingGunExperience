using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSystem : MonoBehaviour
{
    //public AudioSource gunSource;
    public ParticleSystem gunFlash;
    public AudioSource gunSoundSource;
    public Transform bulletDrop;

    public int weaponDamage = 1;

    public GameObject spentBullet;
    public GameObject barrelEffectPrefab;
    public GameObject sandEffectPrefab;

    [SerializeField]
    private LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        gunFlash.Play();
        gunSoundSource.PlayOneShot(gunSoundSource.clip);
        Instantiate(spentBullet, bulletDrop);
        Shoot();
    }

    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, -transform.up, out _hit, 1000, mask))
        {
            if (_hit.collider.tag == "Barrel")
            {
                GameObject _hitEffect = (GameObject)Instantiate(barrelEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(_hitEffect, 2f);

                _hit.collider.gameObject.GetComponent<BarrelDamage>().barrelHP -= weaponDamage;
                _hitEffect.transform.SetParent(_hit.collider.gameObject.transform);
            }
            if (_hit.collider.tag == "Ground")
            {
                GameObject _hitEffect = (GameObject)Instantiate(sandEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(_hitEffect, 2f);
            }
        }
    }
}
