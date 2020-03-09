using UnityEngine;
using VRTK.Controllables;

public class BigWillyRotator : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public VRTK_BaseControllable yawController;
    public Transform ObjectToRotate;
    public Animator gunOscillator;
    private float lastValue;

    private bool osciallation = false;

    protected virtual void OnEnable()
    {
        controllable = controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable;
        yawController = yawController == null ? GetComponent<VRTK_BaseControllable>() : yawController;
        controllable.ValueChanged += ValueChanged;
        yawController.ValueChanged += yawValueChanged;
        lastValue = controllable.GetValue();
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        if (ObjectToRotate != null)
        {
            //float newValue = ObjectToRotate.transform.rotation.z;
            float newValue = controllable.GetValue();
            float crankValue = Mathf.Abs(newValue - lastValue);

            if (crankValue > 5)
            {
                ObjectToRotate.Rotate(0, 0, -5, Space.Self);

            }
            else if (Mathf.Abs(lastValue - newValue) > 5)
            {
                ObjectToRotate.Rotate(0, 0, 5, Space.Self);                
            }
            else
            {
                gunOscillator.SetFloat("crankTime", 0f);
                Debug.Log("*******Do nothing******");
            }

            if (osciallation == true)
            {
                gunOscillator.SetFloat("crankTime", crankValue);
            }

            lastValue = newValue;
        }
    }

    protected virtual void yawValueChanged(object sender, ControllableEventArgs e)
    {
        if (yawController.GetValue() >= 120)
        {
            osciallation = true;
            Debug.Log("Oscillation is now true.");
        }
        else
        {
            Debug.Log("Oscillation is now false");
            osciallation = false;
        }
    }
}