using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringRateButton : MonoBehaviour
{
    public GameObject firingRateConsole;
    FireRateConsoleController consoleControl;

    private void Start()
    {
        consoleControl = firingRateConsole.GetComponent<FireRateConsoleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //sends the gameobject name in the form of a string to consoleControl in the ButtonPressed Function
        consoleControl.ButtonPressed(this.gameObject.transform.name);
    }
}
