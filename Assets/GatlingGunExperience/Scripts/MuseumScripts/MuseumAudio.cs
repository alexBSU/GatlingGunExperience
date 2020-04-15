using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuseumAudio : MonoBehaviour
{
    [SerializeField]
    private float textSpeed; // adjust speed of typewriter effect per second, smaller value is faster

    [SerializeField]
    private float textDelay; // delay in seconds for starting typewriter effect

    [SerializeField]
    private GameObject trackConsole;

    private GameObject currentScript; // reference to current script object
    private GameObject currentImage;

    private int textCounter; // keeps track of character index in the Script
    private int audioIndex; // keeps track of script object index
    private bool textActive; // makes sure typewriter effect only happens once
    private bool scriptActive; // makes sure the script is only activated once
    private bool backHasBeenPressed; //a bool that changeses the functionallity of the back button dependent on how recently it was pressed
    //private bool mainButtonActive;
    public bool scriptPaused; //lets us know when the script is paused
    private string scriptText; // text in the script

    public GameObject[] audioScripts; // array of all script objects
    public GameObject[] images;
    public GameObject background; // background for the scripts
    AudioSource currentAudioTrack; //Refrence the Audiofile currently being used;

    public Material activeMat; // material for button state, can touch
    public Material deactiveMat; // material for button state, can't touch

    bool firstPlay = true;

    public GameObject mainButtonPlaque; //allows us to disable the plaque and replace it with buttons for the second podium
    public GameObject fireRateConsole;
    public Canvas fireRateGraphicsUI;

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes everything when this script is instantiated.
    /// </summary>
    private void Awake()
    {
        //mainButtonActive = false;
        scriptActive = false;
        textActive = false;
        audioIndex = 0;
        textCounter = 0;
    }

    /// <summary>
    /// Checks every frame if user hits the "A" button. Has a base case for the first script object,
    /// followed by the general case. If a script is already playing, nothing happens.
    /// </summary>
    private void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.One) && scriptActive == false && GameManager.isMuseum)
        // {
        //  checkScripts();
        // }
    }

    /// <summary>
    /// Every time the user touches the button. Has a base case for the first script object,
    /// followed by the general case. If a script is already playing, nothing happens.
    /// </summary>
    /// <param name="other"> Collider of the user's hand </param>
    private void OnTriggerEnter(Collider other)
    {
        if (firstPlay == true)
        {
            
            if (mainButtonPlaque != null)
            {
                mainButtonPlaque.SetActive(false);
            }
            checkScripts();
            firstPlay = false;
            trackConsole.SetActive(true);
            //StartCoroutine(TurnIntoNextButton());
        }

        //attempt to set up main button as a next button after sometime, caused problems with trigger detection that isn't currently worth dealing with

        //if (mainButtonActive == true)
        //{
        //    Skip();
        //}

    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Sets up the script for audio to be played.
    /// </summary>
    /// <param name="script"> Reference to the audio source attached the script object </param>
    private void PlayAudio(AudioSource audioTrack)
    {
        Debug.Log("CurrentIndex in PlayAudio function:" + audioIndex);
        currentScript.SetActive(true);
        scriptActive = true;
        //this.GetComponent<Renderer>().material = deactiveMat; // let's the user know that touching the button does nothing
        //float clipLength = audioTrack.clip.length; // used to determine length of coroutine
        startText();
        audioTrack.Play(); // plays audio
    }

    private void StopAudio(AudioSource audioTrack)
    {
        scriptActive = false;
        if (audioTrack != null)
        {
            audioTrack.Stop();
        }
        currentScript.SetActive(false);

    }

    /// <summary>
    /// Sets up typewriter effect.
    /// </summary>
    private void startText()
    {
        Debug.Log("CurrentIndex in startText function:" + audioIndex);
        textCounter = 0;
        scriptText = currentScript.GetComponent<Text>().text; // reference to the current script's text /////
        currentScript.GetComponent<Text>().text = ""; // empties current script's text
        if (!textActive)
        {
            InvokeRepeating("Type", textDelay, textSpeed); // Executes Type() after a delay in seconds, at a frequency of "textSpeed" per second.
        }
    }

    /// <summary>
    /// Typewriter effect. At this point in time, the script's text is empty. Everytime this method is called, the script's text is being
    /// added one character at a time from a reference to the original script. 
    /// </summary>
    private void Type()
    {
        textActive = true;
        currentScript.GetComponent<Text>().text = currentScript.GetComponent<Text>().text + scriptText[textCounter];

        if (textCounter >= scriptText.Length) // cancels method calls once all characters have been set
        {
            textActive = false;
            CancelInvoke("Type");
        } else
        {
            textCounter++;
        }
    }
    private void checkScripts()
    {

        //if (audioIndex > audioScripts.Length) // resets index if it is out of bounds
        //{
        //    audioIndex = 0;
        //}
        if (audioIndex == 0 && scriptActive == false)
        {
            background.SetActive(true);
            currentScript = audioScripts[audioIndex];
            if (images.Length != 0)
            {
                currentImage = images[audioIndex];
                currentImage.SetActive(true);
            }
            if (currentScript.GetComponent<AudioSource>() != null)
            {
                currentAudioTrack = currentScript.GetComponent<AudioSource>();
                PlayAudio(currentAudioTrack);
            } else //if there is no audio skip the PlayAudio function... this is getting messy
            {
                currentScript.SetActive(true);
                scriptActive = true;
                startText();
            }
        }
        else if (audioIndex > 0 && scriptActive == false)
        {
            currentScript = audioScripts[audioIndex];
            if (images.Length != 0)
            {
                currentImage.SetActive(false);
                currentImage = images[audioIndex];
                currentImage.SetActive(true);
            }
            if (currentScript.GetComponent<AudioSource>() != null)
            {
                currentAudioTrack = currentScript.GetComponent<AudioSource>();
                PlayAudio(currentAudioTrack);
            }
            else //if there is no audio skip the PlayAudio function... this is getting messy
            {
                if (audioIndex == 1 && fireRateConsole != null)
                {
                    fireRateConsole.SetActive(true);
                    fireRateGraphicsUI.enabled = true;
                }
                currentScript.SetActive(true);
                scriptActive = true;
                startText();
            }
        }
    }

    /// <summary>
    /// Allows code to be executed after the audio has stopped playing without checking every frame.
    /// </summary>
    /// <param name="clipLength"> Length of the current script's audio source in seconds</param>
    /// <returns></returns>
    #endregion

    #region Track Controls

    public void Pause()
    {
        if (!scriptPaused)
        {
            //Cancels Typing
            CancelInvoke("Type");
            //Pauses Audio Track
            if (currentAudioTrack != null)
            {
                currentAudioTrack.Pause();
            }
            scriptPaused = true;
        }
    }

    public void Play()
    {
        if (scriptPaused)
        {
            if (currentAudioTrack != null)
            {
                currentAudioTrack.Play();
            }
            InvokeRepeating("Type", textDelay, textSpeed);
            scriptPaused = false;
        }

    }

    public void Skip()
    {
        //cancels Type invoke
        CancelInvoke("Type");
        //lets us know the text is not active, allowing it to start again
        textActive = false;
        //stops Audio
        if (currentAudioTrack != null)
        {
            StopAudio(currentAudioTrack);
        }
        //sets the UI objects script back to its original state
        currentScript.GetComponent<Text>().text = scriptText;
        //disables image
        if (currentImage != null)
        {
            currentImage.SetActive(false);
        }
        //adds to the index so that check scripts will put us on to the next section
        //needs to happen after the last played UI object is reset
        currentScript.SetActive(false);
        if (audioIndex < audioScripts.Length)
        {
            audioIndex++;
        } else
        {
            audioIndex = 0;
        }
        //Restarts the process
        scriptActive = false;
        checkScripts();
    }

    public void Back()
    {

        //cancels Type invoke
        CancelInvoke("Type");
        //lets us know the text is not active, allowing it to start again
        textActive = false;
        //stops Audio
        if (currentAudioTrack != null)
        {
            StopAudio(currentAudioTrack);
        }
        //sets the UI objects script back to its original state
        currentScript.GetComponent<Text>().text = scriptText;
        //if this is the first section, don't set the index back further
        if (audioIndex > 0)
        {
            if (backHasBeenPressed == true)
            {
                if (currentImage != null)
                {
                    currentImage.SetActive(false);
                }
                audioIndex--;
            }
            else
            {
                backHasBeenPressed = true;
            }
        }
       
        StartCoroutine(BackDoublePressDelay());
        scriptActive = false;
        //Restarts the process
        checkScripts();
    }
    #endregion

  

    #region Coroutines

    IEnumerator BackDoublePressDelay()
    {
        yield return new WaitForSeconds(4);
        backHasBeenPressed = false;
    }

    //attempt to set up main button as a next button after sometime, caused problems with trigger detection that isn't currently worth dealing with
    //IEnumerator TurnIntoNextButton()
    //{
    //    yield return new WaitForSeconds(12);
    //    //code to trun button into next button;
    //    mainButtonActive = true;
    //}

    #endregion
}
