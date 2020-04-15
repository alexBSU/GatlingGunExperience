using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackButton : MonoBehaviour
{
    public GameObject TrackConsole;
    TrackController trackControl;

    private void Start()
    {
        trackControl = TrackConsole.GetComponent<TrackController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //sends the gameobject name in the form of a string to MuseumAudio in the ButtonPressed Function
        trackControl.ButtonPressed(this.gameObject.transform.name);
    }
}
