using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderParam : MonoBehaviour
{

    // using the Extrude Faces shader from
    // http://shaderslab.com/demo-82---extrude-faces.html

    // create a reference to the renderer
    Renderer rend;

    // a value to manipulate and use for the shader's Factor parameter
    float myVal = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // link to renderer
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // increment to animate
        myVal += .01f;

        // use sine wave to animate the effect
        float sineVal = Mathf.Abs(Mathf.Sin(myVal));

        Debug.Log(sineVal);
        // set the value within the shader
        // common convention is to simply proceed it with an underscore
        rend.material.SetFloat("_Factor", sineVal);

    }
}
