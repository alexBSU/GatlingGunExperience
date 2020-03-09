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
        if (GetComponent<Transform>().childCount - 1 >= 3)
        {
            Destroy(GetComponent<Transform>().GetChild(GetComponent<Transform>().childCount - 1).gameObject);
        }
        

        Debug.Log("Destroy Bullet From Magazine Case Here!!*****");
       
        if (currentmagazineAmmo > 0)
        {
            currentmagazineAmmo -= 1;
        }
        else
        {
            Debug.Log("There is now more ammo in this Magazine!");
            return;
        }
    }
}
