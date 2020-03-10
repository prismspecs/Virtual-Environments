using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusInput : MonoBehaviour
{
    // keep track of whether controller is "inside" other object
    private bool isInside = false;

    // what object are we grabbing
    private GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check out https://developer.oculus.com/documentation/unity/unity-ovrinput/?locale=en_US&device=RIFT
        // for a full list of available methods/arguments to OVRInput
        //float test = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        //Debug.Log(test);

        float trig = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        //Debug.Log(trig);

        if (isInside)
        {
            
            if (trig >= 1.0f)
            {
                targetObj.GetComponent<Rigidbody>().isKinematic = true;
                targetObj.transform.position = transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "Cube")
        {
            Debug.Log("In Cube");
            isInside = true;
            targetObj = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Cube")
        {
            isInside = false;
            targetObj = null;
        }
    }
}
