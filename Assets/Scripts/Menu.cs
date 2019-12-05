using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    FaderScript faderScript;

    IEnumerator GotoMuseum()
    {
        faderScript.FadeIn();
        yield return new WaitForSeconds(0.5f);
        faderScript.blackout.enabled = true;
        yield return new WaitForSeconds(0.5f);
        faderScript.blackout.enabled = false;
        faderScript.FadeOut();
    }


}
