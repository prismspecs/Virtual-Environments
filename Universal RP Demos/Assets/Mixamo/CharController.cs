using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    // create a reference to the Animator component
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // link the animator component to our anim variable
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get keyboard movement and store to variable
        float forwardSpeed = Input.GetAxis("Vertical");
        anim.SetFloat("speed", forwardSpeed);

        Debug.Log(forwardSpeed);    // output in console

        // add forward motion
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // with turning, note that this is in degrees per second
        float turnSpeed = Input.GetAxis("Horizontal");
        // rotate around Y axis
        transform.Rotate(Vector3.up * turnSpeed * 180f * Time.deltaTime);

        // jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // send the animator the jump trigger
            anim.SetTrigger("jump");
        }
    }
}
