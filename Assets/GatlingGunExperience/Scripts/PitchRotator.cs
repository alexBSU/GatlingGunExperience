using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class PitchRotator : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Transform ObjectToPitch;
    private float lastValue;

    protected virtual void OnEnable()
    {
        controllable = controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable;
        controllable.ValueChanged += ValueChanged;
        lastValue = controllable.GetValue();
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        if (ObjectToPitch != null)
        {
            float newValue = controllable.GetValue();

            if (newValue - lastValue > Mathf.Abs(4))
            {
                Debug.Log(ObjectToPitch + " is now pitching up************************.");
                ObjectToPitch.Rotate(0.5f, 0, 0, Space.Self);
            }
            else if (lastValue - newValue > Mathf.Abs(4))
            {
                Debug.Log(ObjectToPitch + " is now pitching down*************************.");
                ObjectToPitch.Rotate(-0.5f, 0, 0, Space.Self);
            }
            else
            {
                Debug.Log("*******Do nothing******");
            }

            lastValue = newValue;
        }
    }
}
