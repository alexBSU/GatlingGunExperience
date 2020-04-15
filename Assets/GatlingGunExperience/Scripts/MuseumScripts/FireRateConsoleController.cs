using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateConsoleController : MonoBehaviour
{
    public GameObject muzzleButton;
    public GameObject muzzlePlayButton;
    public GameObject muzzlePauseButton;

    public GameObject gatlingButton;
    public GameObject gatlingPlayButton;
    public GameObject gatlingPauseButton;

    public GameObject laterGatlingButton;
    public GameObject laterGatlingPlayButton; 
    public GameObject laterGatlingPauseButton;

    public bool muzzlePressed;
    public bool gatlingPressed;
    public bool laterGatlingPressed;

    int menuSet;

    void Start()
    {
        menuSet = 0;
        muzzlePressed = false;
        gatlingPressed = false;
        laterGatlingPressed = false;
    }

    public void ButtonPressed(string pressedButton)
    {
        //muzzle
        if (pressedButton == "MuzzleButton")
        {
            muzzleButton.GetComponent<Collider>().isTrigger = false;
            menuSet = 1;
            StartCoroutine(MenuDelay());

            if (muzzlePressed == false)
            {
                muzzlePressed = true;
                muzzlePlayButton.SetActive(false);
                muzzlePauseButton.SetActive(true);
            } else
            {
                muzzlePressed = false;
                muzzlePlayButton.SetActive(true);
                muzzlePauseButton.SetActive(false);
            }

            
        }

        if (pressedButton == "GatlingButton")
        {
            gatlingButton.GetComponent<Collider>().isTrigger = false;
            menuSet = 2;
            StartCoroutine(MenuDelay());

            if (gatlingPressed == false)
            {
                gatlingPressed = true;
                gatlingPlayButton.SetActive(false);
                gatlingPauseButton.SetActive(true);
            } else 
            {
                gatlingPressed = false;
                gatlingPlayButton.SetActive(true);
                gatlingPauseButton.SetActive(false);
            }

            
        }

        if (pressedButton == "LaterGatlingButton")
        {
            laterGatlingButton.GetComponent<Collider>().isTrigger = false;
            menuSet = 3;
            StartCoroutine(MenuDelay());

            if (laterGatlingPressed == false)
            {
                laterGatlingPressed = true;
                laterGatlingPlayButton.SetActive(false);
                laterGatlingPauseButton.SetActive(true);
            } else
            {
                laterGatlingPressed = false;
                laterGatlingPlayButton.SetActive(true);
                laterGatlingPauseButton.SetActive(false);
            }

            
        }

    }

    //delays the button functionality so that we don't press multiple times on accident
    IEnumerator MenuDelay()
    {
        yield return new WaitForSeconds(4);
        if (menuSet == 1)
        {
            muzzleButton.GetComponent<Collider>().isTrigger = true;
        }
        if (menuSet == 2)
        {
            gatlingButton.GetComponent<Collider>().isTrigger = true;
        }
        if (menuSet == 3)
        {
            laterGatlingButton.GetComponent<Collider>().isTrigger = true;
        }
      
    }
    // Update is called once per frame
    void Update()
    {

    }


}
