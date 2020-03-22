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
        foreach (Transform child in transform)
        {
            if (child.tag == "CustomHand")
                child.gameObject.SetActive(false);
        }
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
