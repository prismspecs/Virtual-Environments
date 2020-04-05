using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandomFade : MonoBehaviour
{

    public Light myLight;

    public float FlickerInterval = 0.5f;
    private float FlickerIntervalPadding = 0.0f;    // used for randomness
    public float FlickerRandomness = .1f;
    private float LastLightFlicker = 0.0f;

    // it will oscillate between two colors,
    // one could just be black (no light)
    public Color Color1 = Color.black;
    public Color Color2 = Color.red;

    public float Frequency = .1f;

    // Start is called before the first frame update
    void Start()
    {
        // a coroutine runs independently from the update function,
        // it's good to refrain from putting many things in Update as they
        // can block other things from proceeding on slower systems
        StartCoroutine("FadeLight");
    }

    IEnumerator FadeLight()
    {

        while(true){ 

            // use the Mathf.Sin method to create a wave
            // so we get smooth values oscillating from -1 to 1
            float t = Mathf.Sin(Time.time * Frequency);

            // since sine returns a value between -1 and 1, we need to re-map this
            // to 0->1 so that it is useful for doing color operations

            // one method is some simple arithmatic
            t += 1;     // add one (now range is 0->2
            t *= .5f;   // divide by 2 (now range is 0->1)
            
            // alternatively, just use the absolute value
            // this keeps the frequency correct anyway
            t = Mathf.Abs(t);

            // interpolate between the two given colors using t,
            // so basically smoothly go from Color1 when t is 0.0
            // to Color2 when t is 1.0
            // for example, t=.5 would return a color exactly in the middle
            Color LerpedColor = Color.Lerp(Color1, Color2, t);

            // for diagnostic purposes if we want
            Debug.Log(t);

            // turn the light the color of the interpolated color
            myLight.color = LerpedColor;

            /*
            // MORE VARIATION METHOD: add a second wave for more variation
            float t1 = Mathf.Sin(Time.time * Frequency);
            float t2 = Mathf.Cos(Time.time * Frequency * 1.3f); // some arbitrary multiplier
            t1 = Mathf.Abs(t1);
            t2 = Mathf.Abs(t2);

            float combinedWaves = (t1 + t2) / 2;
            Color LerpedColor = Color.Lerp(Color1, Color2, combinedWaves);
            myLight.color = LerpedColor;
            */

            // i just want this loop to run as quickly as possible, so
            // i use yield return null, but we could use a WaitForSeconds
            // for more info: https://docs.unity3d.com/Manual/Coroutines.html
            yield return null;
        }
        /*
        if (Time.time >= LastLightFlicker + FlickerIntervalPadding)
        {
            // randomize the next flicker duration
            FlickerIntervalPadding = FlickerInterval + Random.Range(0, FlickerRandomness);

            // reset the timer
            LastLightFlicker = Time.time;
        }
        */
    }
}
