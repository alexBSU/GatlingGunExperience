using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SwitchHandToPose : MonoBehaviour
{
    public void toggleMagHand_R_On()
    {
        GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");


        foreach (Transform child in grabbedObject.transform)
        {
            if (child.tag == "CustomHand_R")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void toggleMagHandR_Off()
    {
        GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

        foreach (Transform child in grabbedObject.transform)
        {
            if (child.tag == "CustomHand_R")
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void toggleMagHand_L_On()
    {
        GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

        foreach (Transform child in grabbedObject.transform)
        {
            if (child.tag == "CustomHand_L")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void toggleMagHand_L_Off()
    {
        GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

        foreach (Transform child in grabbedObject.transform)
        {
            if (child.tag == "CustomHand_L")
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
