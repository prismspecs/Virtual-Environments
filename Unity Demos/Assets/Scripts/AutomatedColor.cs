using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedColor : MonoBehaviour
{
    // public variables mean (among other things) 
    // that you can change them in the editor
    public Color StartColor;
    public Color EndColor;
    public float Duration;

    private float LerpPosition;
    private float Direction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Lerp is short for interpolation
        // it allows you to smoothly move  between values on a spectrum
        // in this case from a start color to and end color
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, LerpPosition);

        // increment it at the desired rate every update:
        LerpPosition += Time.deltaTime / Duration * Direction;

        // make it go forward and backward along the lerp
        if(LerpPosition >= 1f)
        {
            Direction *= -1f;
        }
        if(LerpPosition <= 0f)
        {
            Direction *= -1f;
        }
    }
}
