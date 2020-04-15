using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public GameObject pause;
    public GameObject play;
    public GameObject back;
    public GameObject skip;
    public GameObject MainButton;

    int menuSet;  //int that lets us know what button needs to be delayed

    MuseumAudio mAudio;

    void Start()
    {
        menuSet = 0;
        mAudio = MainButton.GetComponent<MuseumAudio>();
    }

    public void ButtonPressed(string pressedButton)
    {
        
        if (pressedButton == "Pause")
        {
            pause.GetComponent<Collider>().isTrigger = false;
            play.GetComponent<Collider>().isTrigger = true;
            menuSet = 1;
            mAudio.Pause();
        }
        if (pressedButton == "Play")
        {
            play.GetComponent<Collider>().isTrigger = false;
            menuSet = 2;
            mAudio.Play();

        }
        if (pressedButton == "Back")
        {
            back.GetComponent<Collider>().isTrigger = false;
            play.GetComponent<Collider>().isTrigger = false;
            menuSet = 3;
            mAudio.Back();
        }
        if (pressedButton == "Skip")
        {
            skip.GetComponent<Collider>().isTrigger = false;
            play.GetComponent<Collider>().isTrigger = false;
            menuSet = 4;
            mAudio.Skip();
        }
        StartCoroutine(MenuDelay());
    }

    //delays the button functionality so that we don't press multiple times on accident
    IEnumerator MenuDelay ()
    {
        yield return new WaitForSeconds(1.5f);
        if (menuSet == 3)
        {
            back.GetComponent<Collider>().isTrigger = true;
        }
        if (menuSet == 4)
        {
            skip.GetComponent<Collider>().isTrigger = true;
        }
    }
}
