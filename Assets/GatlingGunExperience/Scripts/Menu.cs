using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject player;
    FaderScript faderScript;
    [SerializeField]
    GameObject firingRangeSpawn;
    [SerializeField]
    GameObject museumSpawn;
    [SerializeField]
    GameObject assemblySpawn;
    bool transportAllowed = false;

    private void Awake()
    {
        faderScript = GameObject.FindWithTag("FadeScript").GetComponent<FaderScript>();
        faderScript.enabled = false;
        player = GameObject.FindWithTag("Player");
        transportAllowed = true;
    }

    public void Transport(string location)
    {
        if (transportAllowed == true)
        {
            transportAllowed = false;
            StartCoroutine(GotoLocation(location));
        }
        else
        {
            Debug.Log("Transport Error: Transport not allowed");
        }
    }

    IEnumerator GotoLocation(string location)
    {
        faderScript.FadeIn();
        yield return new WaitForSeconds(faderScript.fadeSpeed);
        faderScript.blackout.enabled = true;

        if (location == "Museum")
        {
            player.transform.position = museumSpawn.transform.position;
            player.transform.rotation = museumSpawn.transform.rotation;
        }
        else if (location == "Assembly")
        {
            player.transform.position = assemblySpawn.transform.position;
            player.transform.rotation = assemblySpawn.transform.rotation;
        }
        else if (location == "FiringRange")
        {
            player.transform.position = firingRangeSpawn.transform.position;
            player.transform.rotation = firingRangeSpawn.transform.rotation;
        }
        else
        {
            Debug.Log("Transport Error: Transport location not found");
        }

        yield return new WaitForSeconds(faderScript.fadeTime - (faderScript.fadeSpeed*2));
        faderScript.blackout.enabled = false;
        faderScript.FadeOut();
        yield return new WaitForSeconds(faderScript.fadeSpeed);
        transportAllowed = true;
    }
}
