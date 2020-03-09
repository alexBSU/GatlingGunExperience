using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    private Rigidbody bulletRB;

    public float casingSpeed = 1;

    // Start is called before the first frame update
    void Awake()
    {
        bulletRB = GetComponent<Rigidbody>();
        //bulletRB.velocity = -transform.up * casingSpeed;
        //bulletRB.velocity = -transform.right * casingSpeed;      
        bulletRB.velocity = new Vector3(Random.Range(-1f, -0.5f), 0, Random.Range(-1, -0.5f)) * casingSpeed;     
    }

    private void FixedUpdate()
    {
        Destroy(this.gameObject, 5f);
    }
}
