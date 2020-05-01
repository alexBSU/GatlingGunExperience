using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SwitchHandToPose : MonoBehaviour
{
    /// <summary>
    /// Toggle for the Magazine Hand Pose
    /// </summary>
    public void toggleHand_R_On()
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
    public void toggleHand_R_Off()
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
    public void toggleHand_L_On()
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
    public void toggleHand_L_Off()
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


    /// <summary>
    /// Toggle for the Gatling Gun Tail Hand Pose
    /// </summary>
    //public void toggleTailHand_R_On()
    //{
    //    GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
    //    Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

    //    foreach (Transform child in grabbedObject.transform)
    //    {
    //        if (child.tag == "CustomHand_R")
    //        {
    //            child.gameObject.SetActive(true);
    //        }
    //    }
    //}
    //public void toggleTailHand_R_Off()
    //{
    //    GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
    //    Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

    //    foreach (Transform child in grabbedObject.transform)
    //    {
    //        if (child.tag == "CustomHand_R")
    //        {
    //            child.gameObject.SetActive(false);
    //        }
    //    }
    //}
    //public void toggleTailHand_L_On()
    //{
    //    GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
    //    Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

    //    foreach (Transform child in grabbedObject.transform)
    //    {
    //        if (child.tag == "CustomHand_L")
    //        {
    //            child.gameObject.SetActive(true);
    //        }
    //    }
    //}
    //public void toggleTailHand_L_Off()
    //{
    //    GameObject grabbedObject = this.gameObject.GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
    //    Debug.Log("current grabbed object is " + grabbedObject.name + "**********************");

    //    foreach (Transform child in grabbedObject.transform)
    //    {
    //        if (child.tag == "CustomHand_L")
    //        {
    //            child.gameObject.SetActive(false);
    //        }
    //    }
    //}
}
