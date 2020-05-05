// further reading on arrays and lists
// https://hub.packtpub.com/arrays-lists-dictionaries-unity-3d-game-development/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{

    // you can create the array and assign it a number of elements
    // all in one go like this
    private AudioSource[] MyAudioSource = new AudioSource[2];

    // you could also do:
    // private AudioSource[] MyAudioSource;
    // and then give it a number of elements in the Start function (commented out below)

    // we need to keep track of which AudioSource is currently playing
    private int CurrentAudioSource = 0;
    // conversely, keep track of the previous AudioSource
    private int PreviousAudioSource = 1;

    // how fast do we want to fade?
    public float FadeSpeed = .25f;

    // optional: use sliders to show mixing
    public Slider[] MySlider = new Slider[2];

    // Start is called before the first frame update
    void Start()
    {
        //MyAudioSource = new AudioSource[2];

        // now that we've declared our array we can assign the two members
        // to some AudioSource components that we are going to add on the fly
        MyAudioSource[0] = gameObject.AddComponent<AudioSource>();
        MyAudioSource[1] = gameObject.AddComponent<AudioSource>();

        // start MyAudioSource[0] at 0 and [1] at 1, because we will
        // fade in [0] first, and the logic below requires it to be
        // less than 1 when we begin
        MyAudioSource[0].volume = 0f;
        MyAudioSource[1].volume = 1f;

        // we're using two AudioSource components bc we are assuming we only need
        // two maximum: we will always fade from one sound to another, no need for
        // multi-channel fading in this example, but you could expand this idea
    }

    // Update is called once per frame
    void Update()
    {
        // if the current AudioSource is not at full volume...
        if (MyAudioSource[CurrentAudioSource].volume < 1f)
        {
            // increase the volume
            MyAudioSource[CurrentAudioSource].volume += FadeSpeed * Time.deltaTime;

            // just max it out at 1 (100%)
            if (MyAudioSource[CurrentAudioSource].volume > 1f)
                MyAudioSource[CurrentAudioSource].volume = 1f;

            // the other AudioSource should always be the opposite of the current one
            MyAudioSource[PreviousAudioSource].volume = 1 - MyAudioSource[CurrentAudioSource].volume;

            Debug.Log(MyAudioSource[PreviousAudioSource].volume);

            // optional: use sliders to show mix
            MySlider[0].value = MyAudioSource[0].volume;
            MySlider[1].value = MyAudioSource[1].volume;
        }
    }

    public void ChangeMusic(AudioClip NewClip)
    {

        // keep track of which AudioSource was playing
        // so that we can fade it out
        PreviousAudioSource = CurrentAudioSource;

        // switch the AudioSource
        if (CurrentAudioSource == 0)
        {
            CurrentAudioSource = 1;
        }
        else
        {
            CurrentAudioSource = 0;
        }

        MyAudioSource[CurrentAudioSource].clip = NewClip;
        MyAudioSource[CurrentAudioSource].Play();

    }
}
