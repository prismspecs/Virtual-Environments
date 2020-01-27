using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// because our script will be referencing an audiosource
// we should make sure the object this script is attached to
// has that component. bonus: it will add one for you!
[RequireComponent(typeof(AudioSource))]

public class TriggerSound : MonoBehaviour
{

    // couple of ways to play audio
    // we will load in a file here for the PlayOneShot method
    public AudioClip MyClip;

    // create a reference to the Audio Source component
    private AudioSource MyAudio;

    // Start is called before the first frame update
    void Start()
    {
        // get the attached Audio Source component and save it as
        // a reference via MyAudio so we can access it later
        MyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // the OnTriggerEnter event is called when another object passes
    // into the collider of this object, so long as the "Trigger" checkbox
    // is enabled on the collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");

        // method 1: PlayOneShot
        // it has two parameters: the clip to play and the volume
        // if you just use the clip, it will assume full volume
        MyAudio.PlayOneShot(MyClip, .5f);

        // method 2: Play the clip that is already loaded in the AudioSource component
        // pay attention the settings there (like Play On Awake)
        //MyAudio.Play();
    }
}
