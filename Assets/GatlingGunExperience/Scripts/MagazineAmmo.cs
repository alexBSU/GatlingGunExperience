using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineAmmo : MonoBehaviour
{
    public int currentmagazineAmmo = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExpendAmmo()
    {
        if (GetComponent<Transform>().childCount - 1 >= 5)
        {
            Destroy(GetComponent<Transform>().GetChild(GetComponent<Transform>().childCount - 1).gameObject);
        }
       
        if (currentmagazineAmmo > 0)
        {
            currentmagazineAmmo -= 1;
        }
        else
        {
            Debug.Log("There is no more ammo in this Magazine!");
            return;
        }
    }
}
