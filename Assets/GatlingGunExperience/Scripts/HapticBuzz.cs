using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticBuzz : MonoBehaviour
{

    OVRHapticsClip buzz;
    public AudioClip audioFile;

    // Start is called before the first frame update
    void Start()
    {
        buzz = new OVRHapticsClip(audioFile);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            OVRHaptics.LeftChannel.Mix(buzz);
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            OVRHaptics.RightChannel.Mix(buzz);
        }
    }
}
