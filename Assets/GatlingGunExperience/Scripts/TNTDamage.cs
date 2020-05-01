using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTDamage : MonoBehaviour
{
    public float tntHP = 10;
    public ParticleSystem explosion;
    public GameObject wagonCart;
    public GameObject wagonCartWrecked;
    public AudioClip boom;
    OVRHapticsClip splode;

    [Header("Explosion Settings")]
    public float eplosionRadius;
    public float explosionForce;

    private void Start()
    {
        splode = new OVRHapticsClip(boom);
    }

    private void FixedUpdate()
    {
        if (tntHP <= 0)
        {
            DestroyTNT();
        }
    }

    void DestroyTNT()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));

        //OVRHapticsClip splode = new OVRHapticsClip(boom);
        OVRHaptics.RightChannel.Mix(splode);
        OVRHaptics.LeftChannel.Mix(splode);

        if (wagonCart != null)
        {
            Destroy(wagonCart);
            Instantiate(wagonCartWrecked, wagonCart.transform.position, wagonCart.transform.rotation);
        }

        Collider[] objects = Physics.OverlapSphere(transform.position, eplosionRadius);
        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(explosionForce, transform.position, eplosionRadius);
            }
        }
    }
}
