using UnityEngine;
using VRTK.Controllables;

public class BigWillyRotator : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Transform ObjectToRotate;
    private float lastValue;

    protected virtual void OnEnable()
    {
        controllable = controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable;
        controllable.ValueChanged += ValueChanged;
        lastValue = controllable.GetValue();
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        if (ObjectToRotate != null)
        {
            //float newValue = ObjectToRotate.transform.rotation.z;
            float newValue = controllable.GetValue();

            if (newValue - lastValue > Mathf.Abs(5))
            {
                if (newValue > lastValue)
                {
                    ObjectToRotate.Rotate(0, 0, 5, Space.Self);
                }
                else
                {
                    //ObjectToRotate.Rotate(0, 0, -2, Space.Self);

                    //play a clink sound??
                }
            }
            lastValue = newValue;
        }
    }
}