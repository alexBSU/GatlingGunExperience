using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDamage : MonoBehaviour
{
    public float barrelHP = 15;
    public GameObject wreckedVersion;

    private void FixedUpdate()
    {
        if (barrelHP <= 0)
        {
            DestroyBarrel();
        }
    }

    void DestroyBarrel()
    {
        Destroy(gameObject);
        Instantiate(wreckedVersion, transform.position, transform.rotation);
    }
}
