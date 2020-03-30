using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingCube : MonoBehaviour
{

    // if you are like me and your headset doesn't have a button
    // one workaround is to "select" by looking at something
    // for some specified amount of time, like over 2 seconds:
    public float LookDurationTrigger = 2.0f;
    // keep track of when they started looking
    private float StartedLookingTime = 0.0f;
    // and a bool to keep track of whether or not they are currently
    // actively gazing at an object
    private bool IsLooking = false;

    // just some  simple public functions to change the color of the cube
    public void StartLooking()
    {
        // normally we would set the color like this:
        //GetComponent<Renderer>().material.color = Color.red;

        // but using Universal Render Pipeline, the standard shaders work
        // a little differently, so we do this:
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);

        // if you want to have it "activate" after a period of time as an
        // alternative to using a button, you'll need to register when the
        // player started looking at the object
        StartedLookingTime = Time.time;

        IsLooking = true;
    }

    public void StopLooking()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);

        IsLooking = false;
    }

    private void Update()
    {
        // if you want to have it "activate" after a period of time as an
        // alternative to using a button, you'll need to now calculate
        // how long the player was looking at the object
        if (IsLooking && Time.time > StartedLookingTime + LookDurationTrigger)
        {
            // ok they looked at it for a while, so call the method that
            // would have been called if they had simply pressed a button
            ActivateLooking();
        }
    }
    public void ActivateLooking()
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue);

        // bonus: experiment with things like making objects fall when you "tap" them
        if(gameObject.GetComponent<Rigidbody>() == null)
        {
            Rigidbody gameObjectsRigidBody = gameObject.AddComponent<Rigidbody>();
            gameObjectsRigidBody.mass = 2;
        }
    }
}
