using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheckForward : MonoBehaviour
{

    public float ViewDistance = 3f;

    void Update()
    {
        // create a vector that shoots out from the center of this object
        // we can create ViewDistance as a public float so we can change it
        // from the editor
        Vector3 forward = transform.TransformDirection(Vector3.forward) * ViewDistance;
        Debug.DrawRay(transform.position, forward, Color.green);

        // need to store data about the raycast hit
        RaycastHit hit;

        // looking in front of this game object, what do we see?
        if (Physics.Raycast(transform.position, forward, out hit, ViewDistance))
        {
            
            if(hit.transform.name.Contains("Player"))
            {
                Debug.Log("I see the player~!");
            }
        }
    }
}
