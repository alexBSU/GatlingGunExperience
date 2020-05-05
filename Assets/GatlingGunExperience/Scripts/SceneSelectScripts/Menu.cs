using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string SceneName;
    public GameObject NavMenu;
    public GameObject ConfirmButton;

    public GameObject ToMuseumText;
    public GameObject ToFiringRangeText;
    public GameObject ToMenuText;

    public float buttonActivationWait = 1.0f;
    public bool ButtonEnabled = false;

    [SerializeField]
    private FaderScript faderScript;

    private void OnEnable()
    {
        ToMuseumText.SetActive(false);
        ToFiringRangeText.SetActive(false);
        ToMenuText.SetActive(false);
        ConfirmButton.SetActive(false);

        StartCoroutine(EnableButton());
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(buttonActivationWait);
        ButtonEnabled = true;
    }

    public void ToConfirmMenu(int menu, string sceneName)
    {
        NavMenu.SetActive(false);
        ConfirmButton.SetActive(true);

        switch (menu)
        {
            case 0:
                SceneName = sceneName;
                ToFiringRangeText.SetActive(false);
                ToMuseumText.SetActive(false);
                ToMenuText.SetActive(true);
                break;
            case 1:
                SceneName = sceneName;
                ToFiringRangeText.SetActive(false);
                ToMenuText.SetActive(false);
                ToMuseumText.SetActive(true);
                break;
            case 2:
                SceneName = sceneName;
                ToMuseumText.SetActive(false);
                ToMenuText.SetActive(false);
                ToFiringRangeText.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid scene ID!");
                break;
        }
    }

    public void ToMainMenu()
    {

        ToMuseumText.SetActive(false);
        ToFiringRangeText.SetActive(false);
        ToMenuText.SetActive(false);

        ConfirmButton.SetActive(false);
        NavMenu.SetActive(true);

    }

    public void SwitchScene()
    {
        if (SceneName != null)
        {
            //SceneManager.LoadScene(SceneName);
            StartCoroutine(SceneSwitcher(SceneName));
            Debug.Log("=============Scene switch called...");
        }
        else
        {
            Debug.LogError("No scene assigned!");
        }
    }

    
    IEnumerator SceneSwitcher(string scene)
    {
        Debug.Log("=============Switching...");

        ButtonEnabled = false;

        Debug.Log("=============Fade out called...");
        faderScript.FadeIn();
        yield return new WaitForSeconds(faderScript.fadeSpeed);
        faderScript.blackout.enabled = true;

        Debug.Log("=============Loading scene...");
        SceneManager.LoadScene(scene);

        yield return new WaitForSeconds(faderScript.fadeTime - (faderScript.fadeSpeed*2));
        faderScript.blackout.enabled = false;
        Debug.Log("=============Fade in called...");
        faderScript.FadeOut();
        yield return new WaitForSeconds(faderScript.fadeSpeed);

        Debug.Log("=============New scene loaded!");
    }
}
