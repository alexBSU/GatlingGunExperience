using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;

    public void OnTriggerEnter(Collider collider)
    {
        SwitchScene(sceneName);
    }

    void SwitchScene(string sceneToLoad)
    {
        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log("No scene available");
        }
    }
}
