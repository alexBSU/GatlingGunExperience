using UnityEngine;
using VRTK.Controllables;

public class BigWillyRotator : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Transform ObjectToRotate;

    protected virtual void OnEnable()
    {
        controllable = controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable;
        controllable.ValueChanged += ValueChanged;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        if (ObjectToRotate != null)
        {
            ObjectToRotate.Rotate(0, 6, 0, Space.Self);
        }
    }
}