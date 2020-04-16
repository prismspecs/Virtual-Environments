using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEmission : MonoBehaviour
{

    // it will oscillate between two colors,
    // one could just be black (no light)
    public Color Color1 = Color.black;
    public Color Color2 = Color.red;

    private Material MyMat;

    public float Frequency = .1f;

    // Start is called before the first frame update
    void Start()
    {
        // note that its a sub property of the Renderer!
        MyMat = GetComponent<Renderer>().material;

        // a coroutine runs independently from the update function,
        // it's good to refrain from putting many things in Update as they
        // can block other things from proceeding on slower systems
        StartCoroutine("FadeLight");
    }

    IEnumerator FadeLight()
    {

        while (true)
        {

            float t1 = Mathf.Sin(Time.time * Frequency);
            t1 += 1;
            t1 *= .5f;

            Color LerpedColor = Color.Lerp(Color1, Color2, t1);

            // if emission was off, you can turn it on with this:
            // MyMat.EnableKeyword("_EMISSION");
            // to set the emission color use the following:
            //MyMat.SetColor("_EmissionColor", LerpedColor);
            // to set it and supply intensity to the color use this
            float Intensity = 1.7f;
            MyMat.SetColor("_EmissionColor", LerpedColor * Intensity);
            // for posterity, changing the color is like this in URP:
            //MyMat.SetColor("_BaseColor", LerpedColor);

            // i just want this loop to run as quickly as possible, so
            // i use yield return null, but we could use a WaitForSeconds
            // for more info: https://docs.unity3d.com/Manual/Coroutines.html
            yield return null;
            //yield return new WaitForSeconds(.1f);   // wait .1 seconds before looping again
        }
    }
}
