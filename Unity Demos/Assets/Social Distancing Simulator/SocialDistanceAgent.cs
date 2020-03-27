using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialDistanceAgent : MonoBehaviour
{

    public bool isSick = false;
    public bool isRecovered = false;
    public bool isDistancing = false;

    // reference to rigidbody so we can addForce and such
    private Rigidbody rb;

    // reference to material so we can change color
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {

        // set references up
        rb = GetComponent<Rigidbody>();
        mat = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {

        // give a random direction sometimes
        if (Random.Range(0f, 10f) > 9f)
        {
            transform.rotation = Random.rotation;
        }

        if(isDistancing)
        {
            // add a little bit of force, to make it wander
            rb.AddForce(transform.forward * 1f);
        } else
        {
            rb.AddForce(transform.forward * 10f);
        }


        // change color based on status
        // this could be done differently so that it isnt constantly being set in update
        if (!isSick)
        {
            mat.color = Color.gray;
        }
        if (isSick)
        {
            mat.color = Color.red;
        }
        if (isRecovered)
        {
            mat.color = Color.green;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // agent collided with something...
        // see if it's with another agent
        if (collision.gameObject.name.Contains("Agent"))
        {
            // now create a reference to the SocialDistanceAgent script on the object this collided with
            SocialDistanceAgent otherAgent = collision.gameObject.GetComponent<SocialDistanceAgent>();

            // now we can do all sorts of stuff, including checking if the other agent is sick
            if (otherAgent.isSick)
            {
                // if agent collided with sick agent, make this agent sick
                // but only if it is currently healthy and hasn't recovered from virus already
                if (!isSick && !isRecovered)
                {
                    isSick = true;
                    Invoke("GetBetter", 20f); // call the GetBetter function after 20 seconds to heal this agent
                }
            }
        }
    }


    void GetBetter()
    {
        isRecovered = true;
        isSick = false;
    }

}
