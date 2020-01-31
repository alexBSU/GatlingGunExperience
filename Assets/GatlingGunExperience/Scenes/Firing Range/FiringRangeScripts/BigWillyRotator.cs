using UnityEngine;
using VRTK.Controllables;

public class BigWillyRotator : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Transform ObjectToRotate;
    public AudioSource gunSource;

    protected virtual void OnEnable()
    {
        controllable = controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable;
        controllable.ValueChanged += ValueChanged;
        
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        if (ObjectToRotate != null)
        {
            ObjectToRotate.Rotate(0, 15, 0, Space.Self);
        }
        if (ObjectToRotate.localEulerAngles.y % 15 == 0)
        {
            gunSource.Play();
        }
    }
}