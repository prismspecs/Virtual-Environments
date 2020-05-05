using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossfade : MonoBehaviour
{
    // array of songs and audio sources
    public AudioClip[] Song;
    public AudioSource[] MyAudioSource;

    private float FadeStartedTime;
    public float FadeDuration = 3f;
    private bool FadeActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // make the first audio source play the first song
        MyAudioSource[0].clip = Song[0];
        MyAudioSource[0].Play();

        // first AS volume is full to start, whereas the second AS is at zero
        MyAudioSource[0].volume = 1;
        MyAudioSource[1].volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // when player hits A key
        if(Input.GetKeyDown(KeyCode.A))
        {
            // log the time we started
            FadeStartedTime = Time.time;
            // set active to true so the transition occurs below
            FadeActive = true;

            // load up the first audio clip and play it (still at zero volume)
            MyAudioSource[1].clip = Song[1];
            MyAudioSource[1].Play();    // play the clip we just loaded
        }

        if(FadeActive)
        {

            // we want to know what percentage (as a number between 0 and 1)
            // the fade is at, so we take the current time and subtract when
            // the fade started, then divide by the total duration of the fade
            // this is a bit confusing, but think of it as this:
            // if the fade started at 5 seconds, then the moment it starts Time.time
            // will be 5 seconds as well, so 5 - 5 = 0 (starting us at zero)
            // and 0 divided by a 3 second duration is still 0
            // if 2 seconds progress beyond that, it would be 7-5=2, and 2/3 = .67
            // so the fade will be 2/3rds done, and so on
            float T = (Time.time - FadeStartedTime) / FadeDuration;

            // log the transition counter
            Debug.Log(T);

            // make the first audio source inversely related to T
            MyAudioSource[0].volume = 1 - T;
            // and the second directly related, so it inreases in volume
            MyAudioSource[1].volume = T;

            // exit this condition if we've gone above 100% volume
            if(T > 1f)
            {
                FadeActive = false;
            }
        }
    }
}
