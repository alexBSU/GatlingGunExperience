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
    public int weaponDamage = 1;
    public GameObject barrelEffectPrefab;

    [SerializeField]
    private LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        gunFlash.Play();
        gunSoundSource.PlayOneShot(gunSoundSource.clip);
        Instantiate(spentBullet, bulletDrop);
        Shoot();
    }

    //void OnHit(Vector3 _pos, Vector3 _normal)
    //{
    //    DoBarrelHitEffect(_pos, _normal);
    //}

    //void DoBarrelHitEffect(Vector3 _pos, Vector3 _normal)
    //{
    //    GameObject _hitEffect = (GameObject)Instantiate(barrelEffectPrefab, _pos, Quaternion.LookRotation(_normal));
    //    Destroy(_hitEffect, 2f);
    //}

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
            }
        }
    }
}
