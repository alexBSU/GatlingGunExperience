using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeceneSelector : MonoBehaviour
{
    public string sceneName;
    public int sceneId;
    private bool isColliding = false;
    [SerializeField]
    private Menu menu;
    //private bool buttonEnabled = false;

    /*private void OnEnable()
    {
        StartCoroutine(EnableButton());
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(menu.buttonActivationWait);
        buttonEnabled = true;
    }*/

    public void OnTriggerEnter(Collider collider)
    {
        //isColliding = true;
        //Debug.Log("=============" + isColliding + " with " + this.gameObject);
        if (menu.ButtonEnabled == true)
        {
            menu.ToConfirmMenu(sceneId, sceneName);
        }
    }

    /*public void OnTriggerExit(Collider collider)
    {
        isColliding = false;
        Debug.Log("=============" + isColliding + " with " + this.gameObject);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (isColliding == true)
            {
                menu.ToConfirmMenu(sceneId, sceneName);
                Debug.Log("=============To Confirm");
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (isColliding == true)
            {
                menu.ToConfirmMenu(sceneId, sceneName);
            }
        }
    }*/
}
