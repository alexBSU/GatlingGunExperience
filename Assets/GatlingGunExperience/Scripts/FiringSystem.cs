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
    public bool spinnningForward;
    public bool hasMagazine = false;

    

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        CheckMag();
        CheckSpinDirection();
        MagazineAmmo magazine = currentMagazine.GetComponent<MagazineAmmo>();
        currentAmmo = magazine.currentmagazineAmmo;

        Debug.Log("The current magazine is: " + magazine.name + "*********************");

        if(hasMagazine == true)
        {
            if (currentAmmo > 0)
            {
                magazine.ExpendAmmo();
                gunFlash.Play();
                gunSoundSource.clip = audioClipArray[1];
                gunSoundSource.PlayOneShot(gunSoundSource.clip);
                Instantiate(spentBullet, bulletDrop);
                Shoot();
                VibrationManager.singleton.TriggerVibration(gunSoundSource.clip, );
            }
            else
            {
                gunSoundSource.clip = audioClipArray[0];
                gunSoundSource.PlayOneShot(gunSoundSource.clip);
            }
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
            if (_hit.collider.tag == "Wagon")
            {
                Rigidbody hitObjectRB = _hit.collider.GetComponent<Rigidbody>();

                if(hitObjectRB.useGravity == false)
                {
                    hitObjectRB.isKinematic = false;
                    hitObjectRB.useGravity = true;                  
                }

                hitObjectRB.AddForce(_hit.point * 20);
                GameObject _hitEffect = (GameObject)Instantiate(barrelEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(_hitEffect, 2f);

                _hitEffect.transform.SetParent(_hit.collider.gameObject.transform);
            }
            if(_hit.collider.tag == "TNT")
            {
                Rigidbody hitObjectRB = _hit.collider.GetComponent<Rigidbody>();

                hitObjectRB.AddForce(_hit.point * 10);

                GameObject _hitEffect = (GameObject)Instantiate(barrelEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(_hitEffect, 2f);

                _hit.collider.gameObject.GetComponent<TNTDamage>().tntHP -= weaponDamage;
                _hitEffect.transform.SetParent(_hit.collider.gameObject.transform);
            }
        }
    }
     public void CheckMag()
    {
        currentMagazine = magazineSnapZone.GetComponent<VRTK_SnapDropZone>().GetCurrentSnappedObject();
    }

    public void CheckSpinDirection()
    {
        //if spinning clockwise spinningForward = true;
        
        //else spinningForward = false;
    }

    public void HasMagazine()
    {
        //called by snapdrop zone VRTK_Snap Drop Zone event
        hasMagazine = true;
    }
    public void HasNoMagazine()
    {
        //called by snapdrop zone VRTK_Snap Drop Zone event
        hasMagazine = false;
    }
}
