using UnityEngine;
using VRTK.Controllables;

public class PitchRotator : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Transform ObjectToPitch;
    public Transform pinScrew;
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

            if (newValue - lastValue > 0)
            {
                Debug.Log(ObjectToPitch + " is now pitching up************************.");
                ObjectToPitch.Rotate(0.2f, 0, 0, Space.Self);

                pinScrew.transform.Translate(0.05f * Vector3.up * Time.deltaTime);
            }
            else if (newValue - lastValue < 0)
            {
                Debug.Log(ObjectToPitch + " is now pitching down*************************.");
                ObjectToPitch.Rotate(-0.2f, 0, 0, Space.Self);

                pinScrew.transform.Translate(-0.05f * Vector3.up * Time.deltaTime);
            }

            lastValue = newValue;
        }
    }
}
