using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderPropertyChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // change the value of a float (Vector1) in the shader
        //GetComponent<Renderer>().material.SetFloat("_Speed", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // control shader speed w keyboard
        GetComponent<Renderer>().material.SetFloat("_Speed", Input.GetAxis("Horizontal") * .05f);
    }
}
