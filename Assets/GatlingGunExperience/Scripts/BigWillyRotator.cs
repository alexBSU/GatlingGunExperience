using UnityEngine;
using VRTK.Controllables;
using VRTK.GrabAttachMechanics;

public class BigWillyRotator : MonoBehaviour
{
    //public VRTK_RotateTransformGrabAttach yawController;
    public Animator gunOscillator;
    public AudioSource yawWheelAudioSound;
    public AudioClip[] yawWheelClips;
    public Transform ObjectToRotate;

    private float oldCrankAngle;
    private float newCrankAngle;
    private float adjustedAngle;
    private bool osciallation = false;

    public static bool clockwise;

    void Update()
    {
        
        //get the degrees from the crank x axis going from 0 to 360 (solves quaternion issues)
        newCrankAngle = Mathf.Atan2(transform.forward.z, transform.forward.y) * Mathf.Rad2Deg;
        if (newCrankAngle <= 0)
        {
            newCrankAngle += 360f;
        }
        //useing *-1 to turn the barrel the correct direction (clockwise)
        ObjectToRotate.transform.localRotation = Quaternion.Euler(0, 0, newCrankAngle * -1);

        //the amount of change in nagle based on movement of the crank
        adjustedAngle = newCrankAngle - oldCrankAngle;

        //setting a bool for Firingsystem to check before firing shoots
        if (adjustedAngle > 0){
            clockwise = true;
        }
        else
        {
            clockwise = false;
        }

        //if the oscillation knob is turned on
        if (osciallation)
        {
            //play the gun oscillation animation (back and forth)
            gunOscillator.SetFloat("crankTime", adjustedAngle);
        }
        //get ref to current angle value
        oldCrankAngle = newCrankAngle;
    }

    public void OscillationON()
    {
        osciallation = true;
        yawWheelAudioSound.clip = yawWheelClips[1];
        yawWheelAudioSound.PlayOneShot(yawWheelAudioSound.clip);

        OVRHapticsClip click = new OVRHapticsClip(yawWheelAudioSound.clip);
        OVRHaptics.LeftChannel.Mix(click);

        Debug.Log("Oscillation is now true.");
    }
    public void OscillationOFF()
    {
        yawWheelAudioSound.clip = yawWheelClips[0];
        yawWheelAudioSound.PlayOneShot(yawWheelAudioSound.clip);

        OVRHapticsClip click = new OVRHapticsClip(yawWheelAudioSound.clip);
        OVRHaptics.LeftChannel.Mix(click);

        Debug.Log("Oscillation is now false");
        osciallation = false;
    }

}