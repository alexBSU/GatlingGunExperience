using UnityEngine;
using VRTK.Controllables;
using VRTK.GrabAttachMechanics;

public class BigWillyRotator : MonoBehaviour
{
    public VRTK_BaseControllable yawController;
    public Animator gunOscillator;
    public AudioSource yawWheelAudioSound;
    public AudioClip[] yawWheelClips;

    public Transform ObjectToRotate;

    public float crankAngle = 0;

    private bool osciallation = false;

    protected virtual void OnEnable()
    {
        yawController = yawController == null ? GetComponent<VRTK_BaseControllable>() : yawController;
    }

    void Update()
    {
        crankAngle = this.transform.localEulerAngles.x;
        Debug.Log("CrankHandle Angle is now: " + crankAngle);
        
        if(crankAngle == 90)
        {
            ObjectToRotate.transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        ObjectToRotate.transform.localEulerAngles = new Vector3(0, 0, this.gameObject.transform.eulerAngles.x);
        Debug.Log("Barrels Angle is now: " + ObjectToRotate.transform.eulerAngles.z);
    }

    //protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    //{
    //    if (ObjectToRotate != null)
    //    {
            //float newValue = ObjectToRotate.transform.rotation.z;
            //float newValue = crankRotation.GetValue();
            //float crankValue = Mathf.Abs(newValue - lastValue);

            //if (crankValue > 5)
            //{
            //    ObjectToRotate.Rotate(0, 0, -5, Space.Self);

            //}
            //else if (Mathf.Abs(lastValue - newValue) > 5)
            //{
            //    ObjectToRotate.Rotate(0, 0, 5, Space.Self);                
            //}
            //else
            //{
            //    gunOscillator.SetFloat("crankTime", 0f);
            //    Debug.Log("*******Do nothing******");
            //}

            //if (osciallation == true)
            //{
            //    gunOscillator.SetFloat("crankTime", crankValue);
            //}

            //lastValue = newValue;
    //    }
    //}

    //protected virtual void yawValueChanged(object sender, ControllableEventArgs e)
    //{
    //    if (yawController.GetValue() >= 90 && osciallation == false)
    //    {
    //        osciallation = true;
    //        yawWheelAudioSound.clip = yawWheelClips[1];
    //        yawWheelAudioSound.PlayOneShot(yawWheelAudioSound.clip);
    //        Debug.Log("Oscillation is now true.");
    //    }
    //    if (yawController.GetValue() <= 90 && osciallation == true)
    //    {
    //        yawWheelAudioSound.clip = yawWheelClips[0];
    //        yawWheelAudioSound.PlayOneShot(yawWheelAudioSound.clip);
    //        Debug.Log("Oscillation is now false");
    //        osciallation = false;
    //    }
    //}

    //public void TurnBarrels(){
    //    //float currentAngle = ObjectToRotate.transform.localRotation.eulerAngles.z;
    //    //float  newAngle = currentAngle + 1;
    //    //Debug.Log("The current angle of the Barrels is: " + currentAngle);

    //    ObjectToRotate.Rotate(0, 0, crankAngle);
    //}

    //public void TurnbarrelsReverse()
    //{
    //    //float currentAngle = ObjectToRotate.transform.localRotation.eulerAngles.z;
    //    //float newAngle = currentAngle - 1;
    //    //Debug.Log("The current angle of the Barrels is: " + currentAngle);

    //    ObjectToRotate.Rotate(0, 0, crankAngle);
    //}
}