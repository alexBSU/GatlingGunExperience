using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;
    private bool isColliding = false;

    /*[SerializeField]
    private GameObject rightHand;
    [SerializeField]
    private GameObject leftHand;
    private bool leftHandColliding = false;
    private bool rightHandColliding = false;*/

    public void OnTriggerEnter(Collider collider)
    {
        isColliding = true;

        /*if (collider == rightHand)
        {
            rightHandColliding = true;
        }

        if (collider == leftHand)
        {
            leftHandColliding = true;
        }*/

        Debug.Log("==============IN " + this.gameObject + ", " + collider);
    }

    public void OnTriggerExit(Collider collider)
    {
        isColliding = false;

        /*if (collider == rightHand)
        {
            rightHandColliding = false;
        }

        if (collider == leftHand)
        {
            leftHandColliding = false;
        }*/

        Debug.Log("==============OUT " + this.gameObject + ", " +  collider);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            /*if (rightHandColliding == true)
            {
                //SwitchScene(sceneName);
                Debug.Log("Right hand click");
            }*/

            if (isColliding == true)
            {
                //SwitchScene(sceneName);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            /*if (leftHandColliding == true)
            {
                SwitchScene(sceneName);
                Debug.Log("Left hand click");
            }*/

            if (isColliding == true)
            {
                //SwitchScene(sceneName);
            }
        }
    }
}
