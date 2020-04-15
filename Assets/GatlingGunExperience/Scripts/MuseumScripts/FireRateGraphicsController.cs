using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRateGraphicsController : MonoBehaviour
{
    public Canvas muzzleCircle;
    public Canvas gatlingCircle;
    public Canvas laterGatlingCircle;

    bool muzzleCycleRunning;
    bool gatlingCycleRunning;
    bool laterGatlingCycleRunning;

    public GameObject fireRateConsole;
    FireRateConsoleController fireRateConsoleControl;

    //AudioSource gunSound;

    // Start is called before the first frame update
    void Start()
    {
        fireRateConsoleControl = fireRateConsole.GetComponent<FireRateConsoleController>();
        //muzzleCycleRunning = false;
        //gunSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fireRateConsoleControl.muzzlePressed == true)
        {
            if (!muzzleCycleRunning)
            {
                MuzzleCycle();
            }
        }
        else
        {
            if (muzzleCycleRunning)
            {
                MuzzleCycleOff();
            }
        }

        if (fireRateConsoleControl.gatlingPressed == true)
        {
            if (!gatlingCycleRunning)
            {
                GatlingCycle();
            }
        }
        else
        {
            if (gatlingCycleRunning)
            {
                GatlingCycleOff();
            }
        }

        if (fireRateConsoleControl.laterGatlingPressed == true)
        {
            if (!laterGatlingCycleRunning)
            {
                LaterGatlingCycle();
            }
        }
        else
        {
            if (laterGatlingCycleRunning)
            {
                LaterGatlingCycleOff();
            }
        }
    }

    void MuzzleCycle()
    {
        if (muzzleCircle.enabled == false)
        {
            muzzleCircle.enabled = true;
        }
    }

    void GatlingCycle()
    {
        if (gatlingCircle.enabled == false)
        {
            gatlingCircle.enabled = true;
        }
    }

    void LaterGatlingCycle()
    {
        if (laterGatlingCircle.enabled == false)
        {
            laterGatlingCircle.enabled = true;
        }
    }

    void MuzzleCycleOff()
    {
        if (muzzleCircle.enabled == true)
        {
            muzzleCircle.enabled = false;
        }
    }

    void GatlingCycleOff()
    {
        if (gatlingCircle.enabled == true)
        {
            gatlingCircle.enabled = false;
        }
    }

    void LaterGatlingCycleOff()
    {
        if (laterGatlingCircle.enabled == true)
        {
            laterGatlingCircle.enabled = false;
        }
    }



    //void MuzzleCycle()
    //{
    //    if (muzzleCycleRunning == false)
    //    {
    //        muzzleCycleRunning = true;
    //        InvokeRepeating("MuzzleCircleAppear", 17, 17);
    //    }
    //}

    //void GatlingCycle()
    //{
    //    if (gatlingCycleRunning == false)
    //    {
    //        gatlingCycleRunning = true;
    //        InvokeRepeating("GatlingCircleAppear", 0.333f, 0.333f);
    //    }
    //}

    //void LaterGatlingCycle()
    //{
    //    if (laterGatlingCycleRunning == false)
    //    {
    //        laterGatlingCycleRunning = true;
    //        InvokeRepeating("LaterGatlingCircleAppear", 0.083f, 0.083f);
    //    }
    //}


    //void MuzzleCircleAppear()
    //{
    //    if (muzzleCircle.enabled == false)
    //    {
    //        muzzleCircle.enabled = true;
    //        StartCoroutine(MuzzleCircleDisable());
    //        gunSound.Play();
    //    }
    //}

    //void GatlingCircleAppear()
    //{
    //    if (gatlingCircle.enabled == false)
    //    {
    //        gatlingCircle.enabled = true;
    //        StartCoroutine(GatlingCircleDisable());
    //        gunSound.Play();
    //    }
    //}

    //void LaterGatlingCircleAppear()
    //{
    //    if (laterGatlingCircle.enabled == false)
    //    {
    //        laterGatlingCircle.enabled = true;
    //        StartCoroutine(LaterGatlingCircleDisable());
    //        gunSound.Play();
    //    }
    //}

    //IEnumerator MuzzleCircleDisable ()
    //{
    //    yield return new WaitForSeconds(2);
    //    muzzleCircle.enabled = false;
    //    muzzleCycleRunning = false;
    //}

    //IEnumerator GatlingCircleDisable()
    //{
    //    yield return new WaitForSeconds(.05f);
    //    gatlingCircle.enabled = false;
    //    gatlingCycleRunning = false;
    //}

    //IEnumerator LaterGatlingCircleDisable()
    //{
    //    yield return new WaitForSeconds(.02f);
    //    laterGatlingCircle.enabled = false;
    //    laterGatlingCycleRunning = false;
    //}
}
