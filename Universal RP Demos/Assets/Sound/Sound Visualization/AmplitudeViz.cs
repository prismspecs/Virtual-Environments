using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeViz : MonoBehaviour
{
    // an AudioSource object so the music can be played  
    private AudioSource aSource;

    // a float array that stores the audio samples  
    public float[] samples = new float[64];

    private Vector3 LastScale;

    private Material MyMat;


    void Awake()
    {
        //Get and store a reference to the following attached components:  
        //AudioSource  
        aSource = GetComponent<AudioSource>();

        LastScale = new Vector3(1, 1, 1);

        MyMat = GetComponent<Renderer>().material;
    }

    void Start()
    {
      
    }

    void Update()
    {
        // obtain the samples from the frequency bands of the attached AudioSource  
        aSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        // running tally of the amplitude
        float amplitude = 0f;

        // loop thru each sample  
        for (int i = 0; i < samples.Length; i++)
        {
            amplitude += samples[i];
        }

        float avg = amplitude / samples.Length * 300f;

        Debug.Log(avg);

        //Vector3 avgVector = new Vector3(avg, avg, avg);
        //transform.localScale = Vector3.Lerp(avgVector, LastScale, .5f);

        MyMat.SetFloat("_Volume", Mathf.Clamp(avg,0,1));
    }
}
