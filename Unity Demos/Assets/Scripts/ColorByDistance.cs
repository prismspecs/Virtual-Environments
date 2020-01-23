using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorByDistance : MonoBehaviour
{

    public Transform other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the other object exists (to avoid errors)
        if (other)
        {
            // calculate the distance between the two positions
            float dist = Vector3.Distance(other.position, transform.position);

            // first method: binary operator to make an object turn color if
            // two objects are near
            /*
            if(dist < 1.0f) // also good to think about from where it is measuring...
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            } else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
            */

            // second method: have the color change gradually based on proximity
            // first use the Remap function (below)
            // in this case we want to define a range of distance (0 to 5) that maps
            // to a "normalized" value of 0 to 1, so that we can use it for a color value
            float mappedValue = Remap(dist, 0, 5, 0, 1);
            Color NewColor = new Color(mappedValue, mappedValue, mappedValue);

            gameObject.GetComponent<Renderer>().material.color = NewColor;

            // print it out for diagnostic purposes
            print("Distance to other: " + dist);
        }
    }

    // a function to "map" the values to a new range
    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
