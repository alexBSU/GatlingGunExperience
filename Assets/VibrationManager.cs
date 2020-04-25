using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VibrationManager : MonoBehaviour
{
    //create singleton of this script so we can call it from any scene
    public static VibrationManager singleton;

    // Start is called before the first frame update
    void Start()
    {
        if(singleton && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
    }

    public void TriggerVibration(AudioClip vibrationAudio, VRTK_DeviceFinder.Devices controller)
    {
        //pass in the audio clip for use with the haptic feedback
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);

        if(controller == VRTK_DeviceFinder.Devices.LeftController)
        {
            //trigger On Left Controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if(controller == VRTK_DeviceFinder.Devices.RightController)
        {
            //trigger On Right Controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}
