using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentReposition : MonoBehaviour
{
    // a reference to the empty game object that tells
    // the game where to place any new children
    public Transform TargetLocation;

    // a public method to be called from the other script
    public void RepositionChild(Transform child)
    {
        // set the child position to the Target Location
        child.transform.position = TargetLocation.position;
    }
}
