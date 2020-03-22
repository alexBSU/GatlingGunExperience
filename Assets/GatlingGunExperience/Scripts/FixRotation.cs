using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    Quaternion rotation;
    public GameObject meMitts_R;

    void Awake()
    {
        rotation = transform.rotation;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
