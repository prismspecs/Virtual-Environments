using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateClip : MonoBehaviour
{
    // you could load in the AudioSource GameObject here
    public Radio MyRadio;

    // have some AudioClip associated with this object
    public AudioClip MyClip;

    // Start is called before the first frame update
    void Start()
    {
        // or you could locate it procedurally here
        // useful if the Radio doesn't exist at start of scene,
        // or if you want to have several AudioSources, etc
        MyRadio = FindObjectOfType<Radio>();
        Debug.Log("Found Radio: " + MyRadio.name);

        //MyRadio.ChangeMusic(MyClip);

        // read in player high score
        Debug.Log("High Score: " + PlayerPrefs.GetInt("highscore"));
    }

    private void OnMouseDown()
    {
        MyRadio.ChangeMusic(MyClip);

        // save player high score
        PlayerPrefs.SetInt("highscore", 100);
    }
}
