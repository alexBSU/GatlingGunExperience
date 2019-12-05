using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaderScript : MonoBehaviour
{
    Image fadeOutUIImage;
    public Image blackout;
    [SerializeField]
    float fadeSpeed = 0.5f;
    [SerializeField]
    enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }

    private void Start()
    {
        fadeOutUIImage = GameObject.FindWithTag("Fader").GetComponent<Image>();
        blackout = GameObject.FindWithTag("Blackout").GetComponent<Image>();
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(FadeDirection.Out));
        Debug.Log("Fade Out");
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(FadeDirection.In));
        Debug.Log("Fade In");
    }

    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;

        //Original code
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    /*public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
    {
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(sceneToLoad);
    }*/
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
}
