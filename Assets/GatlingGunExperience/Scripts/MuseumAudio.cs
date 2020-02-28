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

    private GameObject currentScript; // reference to current script object
    private GameObject currentImage;

    private int textCounter; // keeps track of character index in the Script
    private int audioIndex; // keeps track of script object index
    private bool textActive; // makes sure typewriter effect only happens once
    private bool scriptActive; // makes sure the script is only activated once
    private string scriptText; // text in the script

    public GameObject[] audioScripts; // array of all script objects
    public GameObject[] images;
    public GameObject background; // background for the scripts

    public Material activeMat; // material for button state, can touch
    public Material deactiveMat; // material for button state, can't touch

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes everything when this script is instantiated.
    /// </summary>
    private void Awake()
    {
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
        if (OVRInput.GetDown(OVRInput.Button.One) && scriptActive == false && GameManager.isMuseum)
        {
            checkScripts();
        }
    }

    /// <summary>
    /// Every time the user touches the button. Has a base case for the first script object,
    /// followed by the general case. If a script is already playing, nothing happens.
    /// </summary>
    /// <param name="other"> Collider of the user's hand </param>
    private void OnTriggerEnter(Collider other)
    {
        checkScripts();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Sets up the script for audio to be played.
    /// </summary>
    /// <param name="script"> Reference to the audio source attached the script object </param>
    private void PlayAudio(AudioSource script)
    {
        currentScript.SetActive(true);
        scriptActive = true;
        this.GetComponent<Renderer>().material = deactiveMat; // let's the user know that touching the button does nothing
        float clipLength = script.clip.length; // used to determine length of coroutine
        startText();
        script.Play(); // plays audio
        StartCoroutine(playingAudio(clipLength));
    }

    /// <summary>
    /// Sets up typewriter effect.
    /// </summary>
    private void startText()
    {
        textCounter = 0;
        scriptText = currentScript.GetComponent<Text>().text; // reference to the current script's text
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
        textCounter++;
        if (textCounter == scriptText.Length) // cancels method calls once all characters have been set
        {
            textActive = false;
            CancelInvoke("Type");
        }
    }

    /// <summary>
    /// Hides current script and allows the user to execute another input.
    /// Increases index to repeat the process with the next script in the array. 
    /// </summary>
    private void audioEnd()
    {
        currentScript.SetActive(false);
        audioIndex++;
        scriptActive = false;
        this.GetComponent<Renderer>().material = activeMat;
    }

    private void checkScripts()
    {
        if (audioIndex >= audioScripts.Length) // resets index if it is out of bounds
        {
            audioIndex = 0;
        }
        else if (audioIndex == 0 && scriptActive == false)
        {
            background.SetActive(true);
            currentScript = audioScripts[audioIndex];
            currentImage = images[audioIndex];
            currentImage.SetActive(true);
            PlayAudio(currentScript.GetComponent<AudioSource>());
        }
        else if (audioIndex > 0 && scriptActive == false)
        {
            currentScript = audioScripts[audioIndex];
            currentImage.SetActive(false);
            currentImage = images[audioIndex];
            currentImage.SetActive(true);
            PlayAudio(currentScript.GetComponent<AudioSource>());
        }
    }

    /// <summary>
    /// Allows code to be executed after the audio has stopped playing without checking every frame.
    /// </summary>
    /// <param name="clipLength"> Length of the current script's audio source in seconds</param>
    /// <returns></returns>
    private IEnumerator playingAudio(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        audioEnd();
    }

    #endregion
}