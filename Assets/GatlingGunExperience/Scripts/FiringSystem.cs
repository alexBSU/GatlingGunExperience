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

    MagazineAmmo magazine;

    OVRHapticsClip pop;
    OVRHapticsClip dry;

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        pop = new OVRHapticsClip(audioClipArray[1]);
        dry = new OVRHapticsClip(audioClipArray[0]);
    }

    public void OnTriggerEnter(Collider other)
    {
        CheckMag();
        if (currentMagazine != null)
        {
            MagazineAmmo magazine = currentMagazine.GetComponent<MagazineAmmo>();

            currentAmmo = magazine.currentmagazineAmmo;

            Debug.Log("The current magazine is: " + magazine.name + "*********************");

            if (hasMagazine == true)
            {
                if (currentAmmo > 0 && BigWillyRotator.clockwise)
                {
                    //OVRHapticsClip pop = new OVRHapticsClip(gunSoundSource.clip);
                    OVRHaptics.RightChannel.Mix(pop);
                    OVRHaptics.LeftChannel.Mix(pop);

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

                    //OVRHapticsClip dry = new OVRHapticsClip(gunSoundSource.clip);
                    OVRHaptics.RightChannel.Mix(dry);
                }
            }
        }
        else
        {
            gunSoundSource.clip = audioClipArray[0];
            gunSoundSource.PlayOneShot(gunSoundSource.clip);

            //OVRHapticsClip dry = new OVRHapticsClip(gunSoundSource.clip);
            OVRHaptics.RightChannel.Mix(dry);
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
