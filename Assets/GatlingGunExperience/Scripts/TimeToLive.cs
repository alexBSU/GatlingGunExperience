using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    private Rigidbody bulletRB;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();     
        bulletRB.velocity = new Vector3(Random.Range(-1f, -0.5f), 0, Random.Range(-1, -0.5f));     
    }

    private void FixedUpdate()
    {
        Destroy(this.gameObject, 5f);
    }
}
