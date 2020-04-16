using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// because our script will be referencing an audiosource
// we should make sure the object this script is attached to
// has that component. bonus: it will add one for you!
[RequireComponent(typeof(AudioSource))]

public class CollideSoundArray : MonoBehaviour
{

    // create an array to store multiple Audio Clips
    // note the brackets
    public AudioClip[] MyClips;

    // reference for the Audio Source component for later
    private AudioSource MyAudio;

    // Start is called before the first frame update
    void Start()
    {
        // store the reference
        MyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this works a bit like OnTriggerEnter, except its for
    // objects that collide rather than pass thru
    // the collision object stores info about the object that hit this one
    private void OnCollisionEnter(Collision collision)
    {
        // print the name just to see
        Debug.Log(collision.gameObject.name);

        // we want to play a random member of the MyClips array
        // so we have to generate a random number within the number
        // of elements it has. if there are 5 elements, you want
        // a number between 0 and 4

        int rando = Random.Range(0, MyClips.Length);
        Debug.Log("I picked random number " + rando);

        MyAudio.PlayOneShot(MyClips[rando]);
    }
}
