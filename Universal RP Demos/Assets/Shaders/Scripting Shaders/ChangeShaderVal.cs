using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderVal : MonoBehaviour
{
    // need a reference to this objects material, so we can communicate to shader
    Material myMat;

    // create a float (or bool, or whatever is needed)
    // you can see which properties are exposed in the Matrix.shader file,
    // in our case it looks like this:
    /*
    Properties
	{
		_Grid("Grid", range(1, 50.)) = 30.
		_SpeedMax("Speed Max", range(0, 30.)) = 20.
		_SpeedMin("Speed Min", range(0, 10.)) = 2.
		_Density("Density", range(0, 30.)) = 5.
	}
    */
    // so I can see that "_Grid" is an exposed property that is a float
    // which is why I chose to use it. Also note that it wants values
    // between 1 and 50, and defaults to 30
    float myFloat = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // set a reference to the renderer's material
        myMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // if player presses up or down arrow, increase or decrease float value
        if (Input.GetKeyDown(KeyCode.UpArrow))
            myFloat += 1.0f;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            myFloat -= 1.0f;

        // use that for the _Grid property
        // if you try this out in game mode you should see the shader
        // change when you hit up/down
        myMat.SetFloat("_Grid", myFloat);
    }
}
