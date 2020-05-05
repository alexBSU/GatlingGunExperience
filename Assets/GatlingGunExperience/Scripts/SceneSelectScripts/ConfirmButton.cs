using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField]
    private Menu menu;
    private bool buttonEnabled = false;

    private void OnEnable()
    {
        StartCoroutine(EnableButton());
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(menu.buttonActivationWait);
        buttonEnabled = true;
    }

    public void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("=============" + isColliding + " with " + this.gameObject);
        if(menu.ButtonEnabled == true)
        {
            menu.SwitchScene();
        }
    }
}
