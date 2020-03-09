using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FiringSystem : MonoBehaviour
{
    //public AudioSource gunSource;
    public ParticleSystem gunFlash;
    public AudioSource gunSoundSource;
    public AudioClip[] audioClipArray;
    public Transform bulletDrop;

    public int weaponDamage = 1;

    public GameObject spentBullet;
    public GameObject barrelEffectPrefab;
    public GameObject sandEffectPrefab;
    public GameObject magazineSnapZone;
    public GameObject currentMagazine;

    public int currentAmmo;

    [SerializeField]
    private LayerMask mask;

    private void OnTriggerEnter(Collider other)
    {
        MagazineAmmo magazine = currentMagazine.GetComponent<MagazineAmmo>();
        currentAmmo = magazine.currentmagazineAmmo;
        Debug.Log("Current Ammon is: " + currentAmmo);

        if (currentAmmo > 0)
        {
            magazine.ExpendAmmo();
            gunFlash.Play();
            gunSoundSource.clip = audioClipArray[1];
            gunSoundSource.PlayOneShot(gunSoundSource.clip);
            Instantiate(spentBullet, bulletDrop);
            Shoot();
        }
        else
        {
            gunSoundSource.clip = audioClipArray[0];
            gunSoundSource.PlayOneShot(gunSoundSource.clip);
        }
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
     public void CheckMag()
    {
        Debug.Log("We now have a reference to the current Magazine in the Gatling Gun!*********************************");
        currentMagazine = magazineSnapZone.GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject();
    }

    public void RemovedMag()
    {

    }
}
